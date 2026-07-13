using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common
{
    public abstract class AggregateRoot : AuditableEntity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

       public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

    }
}
