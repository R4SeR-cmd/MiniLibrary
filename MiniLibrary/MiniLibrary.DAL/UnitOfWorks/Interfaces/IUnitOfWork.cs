using MiniLibrary.DAL.Common.Interfaces;

namespace MiniLibrary.DAL.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
