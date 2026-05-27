using Lms.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Data;

//hanterar databasen och tabellerna
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //profile tabellen i databasen
    public DbSet<ProfileEntity> Profiles { get; set; }
    public DbSet<SkillEntity> Skills { get; set; }
    public DbSet<AchievementEntity> Achievements { get; set; }
}
