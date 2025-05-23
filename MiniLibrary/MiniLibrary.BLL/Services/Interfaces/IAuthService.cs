using MiniLibrary.BLL.DTOs;

namespace MiniLibrary.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
