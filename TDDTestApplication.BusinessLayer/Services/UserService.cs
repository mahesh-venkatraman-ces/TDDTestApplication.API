using AutoMapper;
using TDDTestApplication.BusinessLayer.Services.Interfaces;
using TDDTestApplication.BusinessLayer.Utilities.CustomExceptions;
using TDDTestApplication.DataAccessLayer.Entities;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;
using TDDTestApplication.DTO.DTOs;

namespace TDDTestApplication.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var usersToReturn = await _userRepository.GetListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<UserDTO>>(usersToReturn);
        }

        public async Task<UserDTO> GetUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            var userToReturn = await _userRepository.GetAsync(x => x.UserId == userId, cancellationToken);

            if (userToReturn is null)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<UserDTO>(userToReturn);
        }        
    }
}
