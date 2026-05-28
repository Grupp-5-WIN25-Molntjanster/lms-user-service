namespace Lms.UserService.Application.DTOs.Achievements;

public class CreateAchievementRequestDto
{
    public string Title { get; set; } = null!;

    public string Icon { get; set; } = null!;
}