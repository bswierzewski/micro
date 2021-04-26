namespace Core.Entities
{
    public class Version : BaseEntity
    {
        public string Name { get; set; }
        public short Major { get; set; }
        public short Minor { get; set; }
        public short Patch { get; set; }
        public Component Component { get; set; }
        public Kind Kind { get; set; }
        public VersionData VersionData { get; set; }
    }
}