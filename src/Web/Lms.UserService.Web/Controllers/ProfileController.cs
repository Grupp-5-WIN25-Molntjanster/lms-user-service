using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Application.Interfaces.Profile;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Lms.UserService.Web.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    //hämtar in service via dependency injection
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    //hämtar användarens profil
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var userId = "test-user";

        var result = await _profileService.GetProfileAsync(userId);

        return Ok(result);
    }

    //uppdaterar användarens profil
    [HttpPut]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequestDto request)
    {
        var userId = "test-user";

        var result = await _profileService.UpdateProfileAsync(userId, request);

        return Ok(result);
    }
}