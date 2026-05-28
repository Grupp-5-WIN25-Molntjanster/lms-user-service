using Lms.UserService.Application.DTOs.Achievements;
using Lms.UserService.Application.Interfaces.Achievements;
using Lms.UserService.Infrastructure.Data;
using Lms.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Services.Achievements;

public class AchievementService : IAchievementService
{
    // db context för achievements
    private readonly ApplicationDbContext _context;

    public AchievementService(ApplicationDbContext context)
    {
        _context = context;
    }

    // hämtar alla achievements för användaren
    public async Task<IEnumerable<AchievementResponseDto>> GetAchievementsAsync(string userId)
    {
        var achievements = await _context.Achievements
            .Where(x => x.UserId == userId)
            .ToListAsync();

        // skickar tillbaka datan som dto
        return achievements.Select(x => new AchievementResponseDto
        {
            Id = x.Id,
            Title = x.Title,
            Icon = x.Icon
        });
    }

    // skapar nytt achievement
    public async Task<AchievementResponseDto> CreateAchievementAsync(
        string userId,
        CreateAchievementRequestDto request)
    {
        var achievement = new AchievementEntity
        {
            // skapar nytt guid id
            Id = Guid.NewGuid(),

            UserId = userId,
            Title = request.Title,
            Icon = request.Icon
        };

        // lägger till i databasen
        _context.Achievements.Add(achievement);

        await _context.SaveChangesAsync();

        // returnerar nya achievementet
        return new AchievementResponseDto
        {
            Id = achievement.Id,
            Title = achievement.Title,
            Icon = achievement.Icon
        };
    }

    // tar bort achievement
    public async Task DeleteAchievementAsync(Guid id, string userId)
    {
        // letar efter rätt achievement för användaren
        var achievement = await _context.Achievements
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId);

        // om inget hittas
        if (achievement == null)
            return;

        // tar bort från databasen
        _context.Achievements.Remove(achievement);

        await _context.SaveChangesAsync();
    }
}