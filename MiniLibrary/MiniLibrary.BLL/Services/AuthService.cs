using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniLibrary.BLL.DTOs;
using MiniLibrary.BLL.Services.Interfaces;
using MiniLibrary.DAL.Entity;
using MiniLibrary.DAL.UnitOfWorks.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace MiniLibrary.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;


        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration config,
            RoleManager<IdentityRole> roleManager 
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _roleManager = roleManager; 
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

           
            if (!await _roleManager.RoleExistsAsync(dto.Role))
                throw new Exception("Role does not exist");

            await _userManager.AddToRoleAsync(user, dto.Role);

            return GenerateToken(user);
        }


        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                throw new Exception("Invalid credentials");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var userRoles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
