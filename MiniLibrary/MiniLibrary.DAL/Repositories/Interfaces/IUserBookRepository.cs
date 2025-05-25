using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Repositories.Interfaces
{
    public interface IUserBookRepository
    {
        Task AddAsync(UserBook userBook);
        Task<List<UserBook>> GetBooksByUserIdAsync(int userId);
        Task<UserBook?> GetByIdAsync(int id);
        void Delete(int id);
        Task UpdateAsync(UserBook userBook);
    }
}
