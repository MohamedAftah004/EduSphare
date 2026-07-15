using EduSphare.Application.Auth;
using EduSphare.Domain.Verifications;
using Microsoft.EntityFrameworkCore;

namespace EduSphare.Infrastructure.Persistence.Repositories;

public sealed class VerificationRepository : IVerificationRepository
{
    private readonly AppDbContext _context;

    public VerificationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Verification verification,
        CancellationToken cancellationToken = default)
    {
        await _context.Verifications.AddAsync(
            verification,
            cancellationToken);
    }

    public async Task<Verification?> GetLatestAsync(
        Guid userId,
        VerificationPurpose purpose,
        CancellationToken cancellationToken = default)
    {
        return await _context.Verifications
            .Where(x =>
                x.UserId == userId &&
                x.Purpose == purpose)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(cancellationToken);
    }
}