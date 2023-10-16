using TDDTestApplication.DTO.DTOs;

namespace TDDTestApplication.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<UserDTO> GetUserAsync(int userId, CancellationToken cancellationToken = default);
    }
}
