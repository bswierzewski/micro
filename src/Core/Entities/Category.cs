using System.Collections.Generic;

namespace Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}
