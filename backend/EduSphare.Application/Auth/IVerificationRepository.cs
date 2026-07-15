using EduSphare.Domain.Verifications;

namespace EduSphare.Application.Auth
{
    public interface IVerificationRepository
    {
        Task AddAsync(Verification verification, CancellationToken cancellation = default);

        Task<Verification?> GetLatestAsync(
            Guid userId,
            VerificationPurpose purpose,
            CancellationToken cancellation = default
            );

        //void Update(Verification verification);
    }
}
