using Lms.UserService.Application.DTOs.Achievements;
using Lms.UserService.Application.Interfaces.Achievements;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UserService.Web.Controllers.Achievements;

[ApiController]
[Route("api/profile/achievements")]
public class AchievementsController : ControllerBase
{
    private readonly IAchievementService _achievementService;

    public AchievementsController(
        IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAchievements()
    {
        var userId = "test-user";

        var achievements =
            await _achievementService.GetAchievementsAsync(userId);

        return Ok(achievements);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAchievement(
        CreateAchievementRequestDto request)
    {
        var userId = "test-user";

        var achievement =
            await _achievementService.CreateAchievementAsync(
                userId,
                request
            );

        return Ok(achievement);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAchievement(Guid id)
    {
        var userId = "test-user";

        await _achievementService.DeleteAchievementAsync(
            id,
            userId
        );

        return NoContent();
    }
}