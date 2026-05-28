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
    // services som används i controllern
    private readonly IProfileService _profileService;
    private readonly BlobStorageService _blobStorageService;

    // hämtas in via dependency injection
    public ProfileController(
        IProfileService profileService,
        BlobStorageService blobStorageService)
    {
        _profileService = profileService;
        _blobStorageService = blobStorageService;
    }

    // hämtar användarens profile
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        // tillfällig user tills jwt/auth är klart
        var userId = "test-user";

        var result = await _profileService.GetProfileAsync(userId);

        return Ok(result);
    }

    // uppdaterar profile datan
    [HttpPut]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequestDto request)
    {
        // tillfällig user just nu
        var userId = "test-user";

        var result = await _profileService.UpdateProfileAsync(userId, request);

        return Ok(result);
    }

    // upload av profilbild
    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(
        IFormFile file)
    {
        // om ingen fil skickades med
        if (file == null || file.Length == 0)
            return BadRequest("ingen fil uppladdad");

        // laddar upp bilden till azure blob storage
        var imageUrl =
            await _blobStorageService.UploadFileAsync(
                file.OpenReadStream(),
                file.FileName
            );

        // skickar tillbaka bildens url
        return Ok(new
        {
            imageUrl
        });
    }
}