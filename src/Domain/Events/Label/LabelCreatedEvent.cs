using micro_api.Domain.Common;

namespace micro_api.Domain.Events.Label
{
    public class LabelCreatedEvent : DomainEvent
    {
        public Entities.Label Label { get; }

        public LabelCreatedEvent(Entities.Label label)
        {
            Label = label;
        }
    }
}
