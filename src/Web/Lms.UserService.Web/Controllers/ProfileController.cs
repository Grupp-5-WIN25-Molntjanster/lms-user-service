using Lms.UserService.Application.Interfaces.Profile;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UserService.Web.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    //häämtar in service via dependency injection
    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    //hämtar användarens profil
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        var result = await _profileService.GetProfileAsync();

        return Ok(result);
    }
}
