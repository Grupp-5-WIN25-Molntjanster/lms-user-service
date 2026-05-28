using Lms.UserService.Application.DTOs.Skills;
using Lms.UserService.Application.Interfaces.Skills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Lms.UserService.Web.Controllers.Skills;

[ApiController]
[Route("api/profile/skills")]

public class SkillsController : ControllerBase
{
    // service för skills
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    // hämtar alla skills
    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        // tillfällig user tills jwt/auth är klart
        var userId = "test-user";

        var skills = await _skillService.GetSkillsAsync(userId);

        return Ok(skills);
    }

    // skapar ny skill
    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillRequestDto request)
    {
        // test user just nu
        var userId = "test-user";

        var skill = await _skillService.CreateSkillAsync(userId, request);

        return Ok(skill);
    }

    // tar bort skill via id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(Guid id)
    {
        // tillfällig user
        var userId = "test-user";

        await _skillService.DeleteSkillAsync(id, userId);

        return NoContent();
    }
}