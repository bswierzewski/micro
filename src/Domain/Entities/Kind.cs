using micro_api.Domain.Common;

namespace micro_api.Domain.Entities
{
    public class Kind : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
