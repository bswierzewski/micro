using micro_api.Application.Common.Exceptions;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IUnitOfWork _uow;

        public DeleteTodoItemCommandHandler(IUnitOfWork context)
        {
            _uow = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Repository<TodoItem>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            _uow.Repository<TodoItem>().Remove(entity);

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
