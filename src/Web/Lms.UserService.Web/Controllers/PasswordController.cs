using Lms.UserService.Application.DTOs.Password;
using Lms.UserService.Application.Interfaces.Password;
using Microsoft.AspNetCore.Mvc;

namespace Lms.UserService.Web.Controllers;

[ApiController]
[Route("api/profile/password")]
public class PasswordController : ControllerBase
{
    private readonly IPasswordService _passwordService;

    //hämtar service via dependency injection
    public PasswordController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    //byter lösenord
    [HttpPut]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequestDto request)
    {
        var result = await _passwordService.ChangePasswordAsync(request);

        return Ok(result);
    }
}
