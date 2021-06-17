using micro_api.Application.Common.Exceptions;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTodoListCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _uow.Repository<TodoList>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }

            entity.Title = request.Title;

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
