using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace micro_api.Domain.Common
{
    public abstract class BaseEntity : IHasDomainEvent
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        [NotMapped]
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
