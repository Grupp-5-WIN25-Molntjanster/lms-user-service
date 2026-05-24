using Lms.UserService.Infrastructure.Services.Profile;
using Lms.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Lms.UserService.Domain.Entities;

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
}