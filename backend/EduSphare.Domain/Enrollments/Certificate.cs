using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Enrollments.ValueObjects;

namespace EduSphare.Domain.Enrollments
{
    public sealed class Certificate : AuditableEntity
    {
       private Certificate(){}

       public string CertificateNumber { get; private set; }
       public Guid StudentId { get; private set; }
       public Guid CourseId { get; private set; }
       public DateTime IssueDate { get; private set; }
       public CertificateUrl CertificateUrl { get; private set; }



        #region Certificate Behaviorse

        public static Certificate Create(
            string certificateNumber,
            Guid studentId,
            Guid courseId,
            CertificateUrl certificateUrl)
        {
            return new Certificate
            {
                CertificateNumber = certificateNumber,
                StudentId = studentId,
                CourseId = courseId,
                CertificateUrl = certificateUrl,
                IssueDate = DateTime.UtcNow
            };
        }




        #endregion
    }
}
