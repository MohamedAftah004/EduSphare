using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Verifications.Exceptions;

namespace EduSphare.Domain.Verifications
{
    public sealed class Verification : AuditableEntity
    {
        private Verification() { }

       public Guid UserId { get; private set; }
       public string CodeHash { get; private set; }
       public VerificationPurpose Purpose { get; private set; }
       public DateTime ExpiresAt { get; private set; }
       public DateTime? VerifiedAt { get;private set; }

       public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

       public bool IsVerified => VerifiedAt is not null;

       public static Verification Create(
           Guid userId,
           string codeHash,
           VerificationPurpose purpose,
           TimeSpan lifetime)
       {
           ArgumentException.ThrowIfNullOrWhiteSpace(codeHash);

           return new Verification
           {
               
               UserId = userId,
               CodeHash = codeHash,
               Purpose = purpose,
               ExpiresAt = DateTime.UtcNow.Add(lifetime)
           };
       }



       public void Verify(string codeHash)
       {
           ArgumentException.ThrowIfNullOrWhiteSpace(codeHash);

           if (IsVerified)
               throw new VerificationAlreadyVerifiedException();

           if (IsExpired)
               throw new VerificationExpiredException();

           if (CodeHash != codeHash)
               throw new InvalidVerificationCodeException();

           VerifiedAt = DateTime.UtcNow;

           SetUpdated();
       }

    }
}
