using micro_api.Domain.Common;
using micro_api.Domain.Enums;

namespace micro_api.Domain.Entities
{
    public class Label : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressType AddressType { get; set; } = AddressType.Mac;
        public bool IsConfirmed { get; set; }
    }
}
