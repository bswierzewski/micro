namespace Core.Entities
{
    public class Component : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
