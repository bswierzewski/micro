using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class Kind : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
