using MiniLibrary.DAL.Common.Interfaces;
using MiniLibrary.DAL.Repositories.Interfaces;

namespace MiniLibrary.DAL.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        Task<int> SaveChangesAsync();
    }
}
