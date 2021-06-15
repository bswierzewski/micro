using MediatR;
using micro_api.Application.Common.Interfaces;
using micro_api.Application.Common.Models;
using micro_api.Domain.Events.Label;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.Labels.EventHandlers
{
    class LabelCreatedEventHandler : INotificationHandler<DomainEventNotification<LabelCreatedEvent>>
    {
        private readonly ILogger<LabelCreatedEventHandler> _logger;
        private readonly IDateTime _dateTime;

        public LabelCreatedEventHandler(ILogger<LabelCreatedEventHandler> logger, IDateTime dateTime)
        {
            _logger = logger;
            _dateTime = dateTime;
        }

        public Task Handle(DomainEventNotification<LabelCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation($"micro_api Domain Event: {domainEvent.GetType().Name} | Label created: {_dateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
