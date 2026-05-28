using Lms.UserService.Application.DTOs.Achievements;
using Lms.UserService.Application.Interfaces.Achievements;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UserService.Web.Controllers.Achievements;

[ApiController]
[Route("api/profile/achievements")]
public class AchievementsController : ControllerBase
{
    // service för achievements
    private readonly IAchievementService _achievementService;

    public AchievementsController(
        IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    // hämtar alla achievements
    [HttpGet]
    public async Task<IActionResult> GetAchievements()
    {
        // tillfällig user tills auth/jwt finns
        var userId = "test-user";

        var achievements =
            await _achievementService.GetAchievementsAsync(userId);

        return Ok(achievements);
    }

    // skapar nytt achievement
    [HttpPost]
    public async Task<IActionResult> CreateAchievement(
        CreateAchievementRequestDto request)
    {
        // tillfällig test user
        var userId = "test-user";

        var achievement =
            await _achievementService.CreateAchievementAsync(
                userId,
                request
            );

        return Ok(achievement);
    }

    // tar bort achievement via id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAchievement(Guid id)
    {
        // tillfällig user
        var userId = "test-user";

        await _achievementService.DeleteAchievementAsync(
            id,
            userId
        );

        return NoContent();
    }
}