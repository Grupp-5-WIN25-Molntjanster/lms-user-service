using System.ComponentModel.DataAnnotations;

namespace Lms.UserService.Application.DTOs.Skills;

public class CreateSkillRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
}