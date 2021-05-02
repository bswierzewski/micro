using System;

namespace Backend.Dtos
{
    public class VersionDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public int? ModifiedBy { get; set; }
        public string Name { get; set; }
        public short Major { get; set; }
        public short Minor { get; set; }
        public short Patch { get; set; }
        public int? ComponentId { get; set; }
        public int? KindId { get; set; }
        public int? VersionDataId { get; set; }
    }
}