using System.ComponentModel.DataAnnotations;

namespace Lms.UserService.Application.DTOs.Profile;

//datan som frontend skickar in när profilen uppdateras så att asp.net kan kontrollera att:
//namn, efternamn, maxlängd och telenfonformat fnns innan den når servicen
public class UpdateProfileRequestDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Phone]
    public string? PhoneNumber { get; set; }

    [MaxLength(500)]
    public string? Bio { get; set; }

    public string? ProfileImageUrl { get; set; }
}