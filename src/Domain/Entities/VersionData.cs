using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class VersionData : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}
