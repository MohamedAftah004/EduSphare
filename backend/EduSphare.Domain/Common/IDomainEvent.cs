using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common
{
    public interface IDomainEvent : INotification
    {
        DateTime OccuredOn { get; set; }
    }
}
