namespace Core.Entities
{
    public class VersionData : BaseEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}
