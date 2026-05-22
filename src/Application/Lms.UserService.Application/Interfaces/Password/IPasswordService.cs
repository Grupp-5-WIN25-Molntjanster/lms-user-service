using Lms.UserService.Application.DTOs.Password;

namespace Lms.UserService.Application.Interfaces.Password;

public interface IPasswordService
{
    Task<ChangePasswordResponseDto> ChangePasswordAsync(ChangePasswordRequestDto request);
}
