using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Application.Interfaces.Profile;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Lms.UserService.Infrastructure.Services.BlobStorage;

namespace Lms.UserService.Web.Controllers;

[ApiController]
[Route("api/profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly BlobStorageService _blobStorageService;

    //hämtar in service via dependency injection
    public ProfileController(
        IProfileService profileService,
        BlobStorageService blobStorageService)
    {
        _profileService = profileService;
        _blobStorageService = blobStorageService;
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

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(
    IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var imageUrl =
            await _blobStorageService.UploadFileAsync(
    file.OpenReadStream(),
    file.FileName
            );

        return Ok(new
        {
            imageUrl
        });
    }
}