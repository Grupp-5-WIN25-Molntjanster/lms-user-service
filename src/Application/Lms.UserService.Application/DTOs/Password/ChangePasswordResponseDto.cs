namespace Lms.UserService.Application.DTOs.Password;

//svaret som skickas tillbaka efter lösenordsbyte
public class ChangePasswordResponseDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = null!;
}
