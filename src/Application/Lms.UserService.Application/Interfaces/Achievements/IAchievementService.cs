using Lms.UserService.Application.DTOs.Achievements;

namespace Lms.UserService.Application.Interfaces.Achievements;

public interface IAchievementService
{
    Task<IEnumerable<AchievementResponseDto>> GetAchievementsAsync(string userId);

    Task<AchievementResponseDto> CreateAchievementAsync(
        string userId,
        CreateAchievementRequestDto request
    );

    Task DeleteAchievementAsync(Guid id, string userId);
}