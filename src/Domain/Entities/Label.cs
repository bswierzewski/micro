using micro_api.Domain.Common;
using micro_api.Domain.Enums;
using System.Collections.Generic;

namespace micro_api.Domain.Entities
{
    public class Label : BaseEntity, IHasDomainEvent
    {
        public string Name { get; set; }
        public LabelType LabelType { get; set; } = LabelType.Mac;
        public bool IsConfirmed { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
