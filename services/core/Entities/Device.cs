using System;

namespace Core.Entities
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public Address Address { get; set; }
        public Kind Kind { get; set; }
        public Category Category { get; set; }
        public Component Component { get; set; }
        public Version Version { get; set; }
        public bool? IsAutoUpdate { get; set; }
        public bool? IsUpdated { get; set; }
        public DateTime? Updated { get; set; }
    }
}