namespace Lms.UserService.Domain.Entities;

public class AchievementEntity
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Title { get; set; } = null!;
}