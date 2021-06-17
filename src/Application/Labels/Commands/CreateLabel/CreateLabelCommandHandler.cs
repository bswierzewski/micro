using MediatR;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using micro_api.Domain.Events.Label;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.Labels.Commands.CreateLabel
{
    class CreateLabelCommandHandler : IRequestHandler<CreateLabelCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateLabelCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var entity = new Label
            {
                Name = request.Name,
                LabelType = request.LabelType
            };

            entity.DomainEvents.Add(new LabelCreatedEvent(entity));

            await _uow.Repository<Label>().AddAsync(entity);

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
