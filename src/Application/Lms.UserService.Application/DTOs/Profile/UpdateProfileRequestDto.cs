namespace Lms.UserService.Application.DTOs.Profile;

//datan som frontend skickar in när profilen uppdateras
public class UpdateProfileRequestDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }
}