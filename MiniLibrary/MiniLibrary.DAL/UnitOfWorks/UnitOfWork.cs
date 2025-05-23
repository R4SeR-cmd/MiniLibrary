using MiniLibrary.DAL.Common.Interfaces;
using MiniLibrary.DAL.Context;
using MiniLibrary.DAL.UnitOfWorks.Interfaces;

namespace MiniLibrary.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniLibraryDbContext _context;
        public IUserRepository Users { get; }

        public UnitOfWork(MiniLibraryDbContext context, IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
