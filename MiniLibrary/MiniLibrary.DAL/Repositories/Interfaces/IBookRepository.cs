using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetAsync(int id);
        List<Task<Book>> GetAllAsync();
        void Delete(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
