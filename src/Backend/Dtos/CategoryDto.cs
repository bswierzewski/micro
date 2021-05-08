using System;

namespace Backend.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int? ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int[] ComponentIds { get; set; }
    }
}