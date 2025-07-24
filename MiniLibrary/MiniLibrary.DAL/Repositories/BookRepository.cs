using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<Book> GetAsync(string id) => await _context.Books.FindAsync(id);

        public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public void Delete(Book book) => _context.Books.Remove(book);

        public async Task<EntityEntry<Book>> AddAsync(Book book) => await _context.Books.AddAsync(book);

        public void Update(Book book) => _context.Books.Update(book);

        public  IQueryable<Book> GetAllAsQueryable() => _context.Books.AsQueryable();
    }
}
