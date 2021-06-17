using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using micro_api.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<int>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public CreateTodoItemCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.ListId,
                Title = request.Title,
                Done = false
            };

            entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

            await _uow.Repository<TodoItem>().AddAsync(entity);

            await _uow.Complete();

            return entity.Id;
        }
    }
}
