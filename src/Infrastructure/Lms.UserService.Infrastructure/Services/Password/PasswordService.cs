using Lms.UserService.Application.DTOs.Password;
using Lms.UserService.Application.Interfaces.Password;

namespace Lms.UserService.Infrastructure.Services.Password;

//hanterar lösenordsbyte
public class PasswordService : IPasswordService
{
    public async Task<ChangePasswordResponseDto> ChangePasswordAsync(ChangePasswordRequestDto request)
    {
        //mockad lösning just nu
        await Task.CompletedTask;

        return new ChangePasswordResponseDto
        {
            Success = true,
            Message = "Password updated successfully"
        };
    }
}