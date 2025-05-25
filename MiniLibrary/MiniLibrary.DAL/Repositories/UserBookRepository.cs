using MiniLibrary.DAL.Context;
using MiniLibrary.DAL.Entity;
using MiniLibrary.DAL.Repositories.Interfaces;

namespace MiniLibrary.DAL.Repositories
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly MiniLibraryDbContext _context;

        public UserBookRepository(MiniLibraryDbContext context)
        {
            _context = context;
        }


        public Task AddAsync(UserBook userBook)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserBook>> GetBooksByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserBook?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserBook userBook)
        {
            throw new NotImplementedException();
        }
    }
}
