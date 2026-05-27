using Lms.UserService.Application.DTOs.Achievements;
using Lms.UserService.Application.Interfaces.Achievements;
using Lms.UserService.Infrastructure.Data;
using Lms.UserService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Services.Achievements;

public class AchievementService : IAchievementService
{
    private readonly ApplicationDbContext _context;

    public AchievementService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AchievementResponseDto>> GetAchievementsAsync(string userId)
    {
        var achievements = await _context.Achievements
            .Where(x => x.UserId == userId)
            .ToListAsync();

        return achievements.Select(x => new AchievementResponseDto
        {
            Id = x.Id,
            Title = x.Title
        });
    }

    public async Task<AchievementResponseDto> CreateAchievementAsync(
        string userId,
        CreateAchievementRequestDto request)
    {
        var achievement = new AchievementEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = request.Title
        };

        _context.Achievements.Add(achievement);

        await _context.SaveChangesAsync();

        return new AchievementResponseDto
        {
            Id = achievement.Id,
            Title = achievement.Title
        };
    }

    public async Task DeleteAchievementAsync(Guid id, string userId)
    {
        var achievement = await _context.Achievements
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId);

        if (achievement == null)
            return;

        _context.Achievements.Remove(achievement);

        await _context.SaveChangesAsync();
    }
}