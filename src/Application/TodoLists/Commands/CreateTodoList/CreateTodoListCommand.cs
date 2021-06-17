using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public CreateTodoListCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList();

            entity.Title = request.Title;

            await _uow.Repository<TodoList>().AddAsync(entity);

            await _uow.Complete();

            return entity.Id;
        }
    }
}
