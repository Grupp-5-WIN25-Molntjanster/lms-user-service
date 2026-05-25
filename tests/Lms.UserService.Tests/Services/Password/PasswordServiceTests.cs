using Lms.UserService.Application.DTOs.Password;
using Lms.UserService.Infrastructure.Services.Password;
using Microsoft.Extensions.Configuration;

namespace Lms.UserService.Tests.Services.Password;

public class PasswordServiceTests
{
    [Fact]
    public async Task ChangePasswordAsync_Returns_Success_Response()
    {
        //skapar fake appsettings för auth service
        var settings = new Dictionary<string, string?>
{
    { "ServiceUrls:AuthService", "https://localhost:5001/" }
};

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();

        //skapar fake httpclient
        var httpClient = new HttpClient();

        //skapar password service
        var service = new PasswordService(httpClient, configuration);

        //skapar test request
        var request = new ChangePasswordRequestDto
        {
            CurrentPassword = "oldpassword",
            NewPassword = "newpassword"
        };

        //kör change password
        var result = await service.ChangePasswordAsync(request);

        //kontrollerar att response returneras korrekt
        Assert.NotNull(result);

        Assert.True(result.Success);

        Assert.Equal("Password updated successfully", result.Message);
    }
}