using micro_api.Domain.Common;

namespace micro_api.Domain.Events.Label
{
    class LabelCreatedEvent : DomainEvent
    {
        public Entities.Label Label { get; }

        public LabelCreatedEvent(Entities.Label label)
        {
            Label = label;
        }
    }
}
