namespace Lms.UserService.Domain.Entities;

//hämtar användarens profilinfo

public class ProfileEntity
{
    public Guid Id { get; set; }

    //kopplar profilen till användaren från authservice
    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }
}