using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using TDDTestApplication.IntegrationTest.Helpers;

namespace TDDTestApplication.IntegrationTest
{
    public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public UserControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetUsers_WhenAuthTokenIsNotProvided_ReturnsUnauthorized()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();
            }

            // Act
            var response = await _client.GetAsync("api/User/getusers");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
