using MiniLibrary.DAL.Entity;

namespace MiniLibrary.DAL.Common.Interfaces
{
    public interface IUserRepository
    {
        void Delete(User user);
        Task AddAsync(User user);
        void Update(User user);
    }
}
