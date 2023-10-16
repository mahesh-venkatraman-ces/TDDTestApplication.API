using AutoFixture.Xunit2;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using TDDTestApplication.BusinessLayer.Services;
using TDDTestApplication.BusinessLayer.Services.Interfaces;
using TDDTestApplication.BusinessLayer.Utilities.AutomapperProfiles;
using TDDTestApplication.BusinessLayer.Utilities.CustomExceptions;
using TDDTestApplication.DataAccessLayer.Entities;
using TDDTestApplication.DataAccessLayer.Repositories.Interfaces;

namespace TDDTestApplication.UnitTest.Services
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;

        public UserServiceTests()
        {
            var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

            _userService = new UserService(_userRepository.Object, _mapper);
        }

        [Theory]
        [AutoData]
        public async Task GetUsersAsync_WhenSuccess_ReturnsUserDTOList(List<User> users)
        {
            //Arrange
            var userEntityList = users;

            _userRepository
                .Setup(repo => repo.GetListAsync(null!, CancellationToken.None))
                .ReturnsAsync(userEntityList);

            //Act
            var result = await _userService.GetUsersAsync();

            //Assert
            Assert.Equal(2, result.Count);
        }

        [Theory]
        [AutoData]
        public async Task GetUserAsync_WhenSuccess_ReturnsUserDTOList(int userid)
        {
            //Act
            var result = await _userService.GetUserAsync(userid);

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [AutoData]
        public async Task GetUserAsync_WhenUserDoesNotExist_ThrowsUserNotFoundException(int userid)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), CancellationToken.None))
                .ReturnsAsync((User)null!);

            //Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.GetUserAsync(userid));
        }        
    }
}
