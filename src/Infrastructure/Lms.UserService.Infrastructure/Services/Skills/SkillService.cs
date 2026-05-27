using Lms.UserService.Application.DTOs.Skills;
using Lms.UserService.Application.Interfaces.Skills;
using Lms.UserService.Domain.Entities;
using Lms.UserService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lms.UserService.Infrastructure.Services.Skills;

public class SkillService : ISkillService
{
    private readonly ApplicationDbContext _context;

    public SkillService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SkillResponseDto>> GetSkillsAsync(string userId)
    {
        var skills = await _context.Skills
            .Where(x => x.UserId == userId)
            .ToListAsync();

        return skills.Select(skill => new SkillResponseDto
        {
            Id = skill.Id,
            Name = skill.Name
        }).ToList();
    }

    public async Task<SkillResponseDto> CreateSkillAsync(string userId, CreateSkillRequestDto request)
    {
        var skill = new SkillEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Name = request.Name
        };

        _context.Skills.Add(skill);

        await _context.SaveChangesAsync();

        return new SkillResponseDto
        {
            Id = skill.Id,
            Name = skill.Name
        };
    }

    public async Task DeleteSkillAsync(Guid id, string userId)
    {
        var skill = await _context.Skills
            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

        if (skill == null)
            return;

        _context.Skills.Remove(skill);

        await _context.SaveChangesAsync();
    }
}