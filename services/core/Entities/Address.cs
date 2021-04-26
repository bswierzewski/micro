using Core.Entities.Enums;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public string Label { get; set; }
        public AddressType AddressType { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
