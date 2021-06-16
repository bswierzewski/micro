using micro_api.Domain.Common;
using micro_api.Domain.Enums;

namespace micro_api.Domain.Entities
{
    public class Label : AuditableEntity
    {
        public string Name { get; set; }
        public LabelType LabelType { get; set; } = LabelType.Mac;
        public bool IsConfirmed { get; set; }
    }
}
