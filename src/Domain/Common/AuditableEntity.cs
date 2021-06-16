using micro_api.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace micro_api.Domain.Common
{
    public abstract class AuditableEntity : IAuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
