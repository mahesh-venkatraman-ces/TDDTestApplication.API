using AutoMapper;
using TDDTestApplication.BusinessLayer.Services.Interfaces;
using TDDTestApplication.BusinessLayer.Utilities.CustomExceptions;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;
using TDDTestApplication.DTO.DTOs;

namespace TDDTestApplication.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
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
