using System;

namespace Backend.Dtos
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int? ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int? AddressId { get; set; }
        public int? KindId { get; set; }
        public int? ComponentId { get; set; }
        public int? VersionId { get; set; }
        public bool? IsUpdated { get; set; }
        public DateTime? Updated { get; set; }
        public bool? IsAutoUpdate { get; set; }
    }
}