using MiniLibrary.DAL.Context;
using MiniLibrary.DAL.Entity;
using MiniLibrary.DAL.Repositories.Interfaces;

namespace MiniLibrary.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MiniLibraryDbContext _context;

        public BookRepository(MiniLibraryDbContext context)
        {
            _context = context;
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
