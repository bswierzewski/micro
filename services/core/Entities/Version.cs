namespace Core.Entities
{
    public class Version : BaseEntity
    {
        public string Name { get; set; }
        public short Major { get; set; }
        public short Minor { get; set; }
        public short Patch { get; set; }
        public int? ComponentId { get; set; }
        public Component Component { get; set; }
        public int? KindId { get; set; }
        public Kind Kind { get; set; }
        public int? VersionDataId { get; set; }
        public VersionData VersionData { get; set; }
    }
}