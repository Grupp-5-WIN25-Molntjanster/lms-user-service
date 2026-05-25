using Lms.UserService.Application.DTOs.Password;
using Lms.UserService.Application.Interfaces.Password;
using Microsoft.Extensions.Configuration;

namespace Lms.UserService.Infrastructure.Services.Password;

//hanterar lösenordsbyte
public class PasswordService : IPasswordService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public PasswordService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ChangePasswordResponseDto> ChangePasswordAsync(ChangePasswordRequestDto request)
    {
        //hämtar auth service url från appsettings
        var authServiceUrl = _configuration["ServiceUrls:AuthService"];

        //här ska request senare skickas till auth service

        //mockad lösning just nu
        await Task.CompletedTask;

        return new ChangePasswordResponseDto
        {
            Success = true,
            Message = "Password updated successfully"
        };
    }
}