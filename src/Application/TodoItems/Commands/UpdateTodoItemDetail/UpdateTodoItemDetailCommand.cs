using micro_api.Application.Common.Exceptions;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using micro_api.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoItems.Commands.UpdateTodoItemDetail
{
    public class UpdateTodoItemDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public PriorityLevel Priority { get; set; }

        public string Note { get; set; }
    }

    public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTodoItemDetailCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Repository<TodoItem>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.ListId = request.ListId;
            entity.Priority = request.Priority;
            entity.Note = request.Note;

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
