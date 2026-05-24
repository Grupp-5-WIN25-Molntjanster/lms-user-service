using Lms.UserService.Application.DTOs.Profile;

namespace Lms.UserService.Application.Interfaces.Profile;

//vad profile servicen bör lr ska kunna göra
public interface IProfileService
{
    Task<ProfileResponseDto> GetProfileAsync(string userId);

    Task<ProfileResponseDto> UpdateProfileAsync(string userId, UpdateProfileRequestDto request);
}