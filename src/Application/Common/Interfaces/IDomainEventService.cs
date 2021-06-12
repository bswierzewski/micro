using micro_api.Domain.Common;
using System.Threading.Tasks;

namespace micro_api.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
