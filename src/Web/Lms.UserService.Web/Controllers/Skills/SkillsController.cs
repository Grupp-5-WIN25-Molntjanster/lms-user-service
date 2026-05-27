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
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        var userId = User.FindFirstValue("sub");

        if (userId == null)
            return Unauthorized();

        var skills = await _skillService.GetSkillsAsync(userId);

        return Ok(skills);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillRequestDto request)
    {
        var userId = User.FindFirstValue("sub");

        if (userId == null)
            return Unauthorized();

        var skill = await _skillService.CreateSkillAsync(userId, request);

        return Ok(skill);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(Guid id)
    {
        var userId = User.FindFirstValue("sub");

        if (userId == null)
            return Unauthorized();

        await _skillService.DeleteSkillAsync(id, userId);

        return NoContent();
    }
}