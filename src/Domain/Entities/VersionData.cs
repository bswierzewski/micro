using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class VersionData : BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}
