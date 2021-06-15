using micro_api.Domain.Common;
using micro_api.Domain.Enums;
using System.Collections.Generic;

namespace micro_api.Domain.Entities
{
    public class Label : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Mac;
        public bool IsConfirmed { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
