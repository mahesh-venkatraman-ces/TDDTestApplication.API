using TDDTestApplication.DataAccessLayer.Entities;

namespace TDDTestApplication.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UpdateUserAsync(User user);
    }
}
