using micro_api.Domain.Common;
using System.Collections.Generic;

namespace micro_api.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public IList<Component> Components { get; set; } = new List<Component>();
    }
}
