using Microsoft.EntityFrameworkCore.ChangeTracking;
using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetAsync(string id);
        Task<List<Book>> GetAllAsync();
        void Delete(Book book);
        Task<EntityEntry<Book>> AddAsync(Book book);
        void Update(Book book);
        IQueryable <Book> GetAllAsQueryable();
        
    }
}
