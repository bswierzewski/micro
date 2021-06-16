using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class Kind : AuditableEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
