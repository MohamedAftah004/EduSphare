using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }


        public void SetUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
