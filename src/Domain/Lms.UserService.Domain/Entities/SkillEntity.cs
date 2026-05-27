namespace Lms.UserService.Domain.Entities;

public class SkillEntity
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;
}