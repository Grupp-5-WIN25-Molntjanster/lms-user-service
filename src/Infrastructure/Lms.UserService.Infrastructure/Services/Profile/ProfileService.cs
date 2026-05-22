using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Application.Interfaces.Profile;
using Lms.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Services.Profile;

//logiken för profile funktionerna
public class ProfileService : IProfileService
{

    //pratar med databasen
    private readonly ApplicationDbContext _context;

    //hämtar databasen via dependency injection
    public ProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProfileResponseDto> GetProfileAsync()
    {
        //hämtar första profilen från databasen
        var profile = await _context.Profiles.FirstOrDefaultAsync();

        //om ingen profil finns
        if (profile == null)
        {
            return new ProfileResponseDto
            {
                UserId = "",
                FirstName = "",
                LastName = ""
            };
        }

        //skickar tillbaka profildata
        return new ProfileResponseDto
        {
            UserId = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            PhoneNumber = profile.PhoneNumber,
            Bio = profile.Bio,
            ProfileImageUrl = profile.ProfileImageUrl
        };
    }

    public async Task<ProfileResponseDto> UpdateProfileAsync(UpdateProfileRequestDto request)
    {
        //hämtar första profilen från databasen
        var profile = await _context.Profiles.FirstOrDefaultAsync();

        //skapar profil om ingen finns
        if (profile == null)
        {
            profile = new Domain.Entities.ProfileEntity
            {
                Id = Guid.NewGuid(),
                UserId = "123"
            };

            _context.Profiles.Add(profile);
        }

        //uppdaterar profilens värden
        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.PhoneNumber = request.PhoneNumber;
        profile.Bio = request.Bio;
        profile.ProfileImageUrl = request.ProfileImageUrl;

        //sparar till databasen
        await _context.SaveChangesAsync();

        //skickar tillbaka uppdaterad profil
        return new ProfileResponseDto
        {
            UserId = profile.UserId,
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            PhoneNumber = profile.PhoneNumber,
            Bio = profile.Bio,
            ProfileImageUrl = profile.ProfileImageUrl
        };
    }
}