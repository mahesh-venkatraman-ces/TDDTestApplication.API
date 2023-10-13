using TDDTestApplication.DataAccessLayer.DataContext;
using TDDTestApplication.DataAccessLayer.Entities;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;

namespace TDDTestApplication.DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _ = _applicationDbContext.Update(user);

            _applicationDbContext.Entry(user).Property(x => x.Password).IsModified = false;

            await _applicationDbContext.SaveChangesAsync();
            return user;
        }
    }
}
