using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Application.Interfaces.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Lms.UserService.Web.Controllers;

[ApiController]
[Route("api/profile")]
[Authorize]
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
        //hämtar userId från jwt token
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        //om ingen token eller userId finns
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var result = await _profileService.GetProfileAsync(userId);

        return Ok(result);
    }

    //uppdaterar användarens profil
    [HttpPut]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequestDto request)
    {
        //hämtar userId från jwt token
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        //om ingen token eller userId finns
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var result = await _profileService.UpdateProfileAsync(userId, request);

        return Ok(result);
    }
}