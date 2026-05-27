using Lms.UserService.Application.DTOs.Skills;

namespace Lms.UserService.Application.Interfaces.Skills;

public interface ISkillService
{
    Task<List<SkillResponseDto>> GetSkillsAsync(string userId);

    Task<SkillResponseDto> CreateSkillAsync(string userId, CreateSkillRequestDto request);

    Task DeleteSkillAsync(Guid id, string userId);
}