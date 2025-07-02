using MiniLibrary.BLL.DTOs;

namespace MiniLibrary.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserCredentialsDTO dto);
        Task<string> LoginAsync(UserCredentialsDTO dto);
    }
}
