using Lms.UserService.Application.DTOs.Skills;
using Lms.UserService.Application.Interfaces.Skills;
using Lms.UserService.Domain.Entities;
using Lms.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Services.Skills;

public class SkillService : ISkillService
{
    // db context för skills
    private readonly ApplicationDbContext _context;

    public SkillService(ApplicationDbContext context)
    {
        _context = context;
    }

    // hämtar alla skills för användaren
    public async Task<List<SkillResponseDto>> GetSkillsAsync(string userId)
    {
        var skills = await _context.Skills
            .Where(x => x.UserId == userId)
            .ToListAsync();

        // mappar om till dto
        return skills.Select(skill => new SkillResponseDto
        {
            Id = skill.Id,
            Name = skill.Name
        }).ToList();
    }

    // skapar ny skill
    public async Task<SkillResponseDto> CreateSkillAsync(string userId, CreateSkillRequestDto request)
    {
        var skill = new SkillEntity
        {
            // skapar nytt id
            Id = Guid.NewGuid(),

            UserId = userId,
            Name = request.Name
        };

        // sparar i databasen
        _context.Skills.Add(skill);

        await _context.SaveChangesAsync();

        // skickar tillbaka nya skillen
        return new SkillResponseDto
        {
            Id = skill.Id,
            Name = skill.Name
        };
    }

    // tar bort en skill
    public async Task DeleteSkillAsync(Guid id, string userId)
    {
        // letar efter rätt skill
        var skill = await _context.Skills
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        // om den inte finns
        if (skill == null)
            return;

        // tar bort från databasen
        _context.Skills.Remove(skill);

        await _context.SaveChangesAsync();
    }
}