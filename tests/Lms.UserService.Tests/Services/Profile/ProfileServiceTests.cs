using Lms.UserService.Application.DTOs.Profile;
using Lms.UserService.Domain.Entities;
using Lms.UserService.Infrastructure.Data;
using Lms.UserService.Infrastructure.Services.Profile;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Tests.Services.Profile;

public class ProfileServiceTests
{
    [Fact]
    public async Task GetProfileAsync_Returns_Profile()
    {
        //skapar fake databas i minnet
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        //skapar dbcontext
        var context = new ApplicationDbContext(options);

        //lägger in testprofil i databasen
        context.Profiles.Add(new ProfileEntity
        {
            UserId = "user-123",
            FirstName = "Ayler",
            LastName = "Sabbagh",
            Bio = "Test bio"
        });

        await context.SaveChangesAsync();

        //skapar service
        var service = new ProfileService(context);

        //hämtar profil
        var result = await service.GetProfileAsync("user-123");

        //kontrollerar att rätt data returneras
        Assert.NotNull(result);

        Assert.Equal("Ayler", result.FirstName);
        Assert.Equal("Sabbagh", result.LastName);
        Assert.Equal("Test bio", result.Bio);
    }

    [Fact]
    public async Task UpdateProfileAsync_Updates_Profile()
    {
        //skapar fake databas i minnet
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "UpdateProfileDb")
            .Options;

        //skapar dbcontext
        var context = new ApplicationDbContext(options);

        //lägger in testprofil
        context.Profiles.Add(new ProfileEntity
        {
            UserId = "user-123",
            FirstName = "Old",
            LastName = "Name",
            Bio = "Old bio"
        });

        await context.SaveChangesAsync();

        //skapar service
        var service = new ProfileService(context);

        //skapar update request
        var request = new UpdateProfileRequestDto
        {
            FirstName = "New",
            LastName = "Name",
            Bio = "Updated bio"
        };

        //uppdaterar profil
        var result = await service.UpdateProfileAsync("user-123", request);

        //kontrollerar att profilen uppdaterades
        Assert.NotNull(result);

        Assert.Equal("New", result.FirstName);
        Assert.Equal("Name", result.LastName);
        Assert.Equal("Updated bio", result.Bio);
    }
}