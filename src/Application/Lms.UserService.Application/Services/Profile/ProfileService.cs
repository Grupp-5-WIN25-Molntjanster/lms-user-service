using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Application.Interfaces.Profile;

namespace Lms.UserService.Application.Services.Profile;

//logiken för profile funktionerna
public class ProfileService : IProfileService
{
    //tillfällig mockad data tills databasen är kopplad
    public async Task<ProfileResponseDto> GetProfileAsync()
    {
        var profile = new ProfileResponseDto
        {
            UserId = "123",
            FirstName = "Ayler",
            LastName = "Sabbagh",
            PhoneNumber = "0700000000",
            Bio = "Pluggar .NET och bygger ett lms projekt",
            ProfileImageUrl = ""
        };

        return await Task.FromResult(profile);
    }

    //uppdaterar profil med mockad just nu
    public async Task<ProfileResponseDto> UpdateProfileAsync(UpdateProfileRequestDto request)
    {
        var updatedProfile = new ProfileResponseDto
        {
            UserId = "123",
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Bio = request.Bio,
            ProfileImageUrl = request.ProfileImageUrl
        };

        return await Task.FromResult(updatedProfile);
    }
}