using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class Component : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
