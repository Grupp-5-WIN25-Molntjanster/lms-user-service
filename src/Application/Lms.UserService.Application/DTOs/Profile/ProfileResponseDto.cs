namespace Lms.UserService.Application.DTOs.Profile;

//datan som skickas till frontend när användare hämtar sin profil
public class ProfileResponseDto
{
    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }
}