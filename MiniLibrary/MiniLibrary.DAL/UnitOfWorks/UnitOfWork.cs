using MiniLibrary.DAL.Common;
using MiniLibrary.DAL.Common.Interfaces;
using MiniLibrary.DAL.Context;
using MiniLibrary.DAL.Repositories;
using MiniLibrary.DAL.Repositories.Interfaces;
using MiniLibrary.DAL.UnitOfWorks.Interfaces;

namespace MiniLibrary.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniLibraryDbContext _context;
        public IUserRepository Users { get; }
        public IBookRepository Books { get; }
        
        

        public UnitOfWork(MiniLibraryDbContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = new UserRepository(_context);
            Books = new BookRepository(_context);
            
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
