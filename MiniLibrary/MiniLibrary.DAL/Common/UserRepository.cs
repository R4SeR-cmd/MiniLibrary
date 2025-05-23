using MiniLibrary.DAL.Common.Interfaces;
using MiniLibrary.DAL.Context;
using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Common
{
    public class UserRepository : IUserRepository
    {
        private readonly MiniLibraryDbContext _context;

        public UserRepository(MiniLibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public void Update(User user) => _context.Users.Update(user);

        public void Delete(User user) => _context.Users.Remove(user);
    }
}
