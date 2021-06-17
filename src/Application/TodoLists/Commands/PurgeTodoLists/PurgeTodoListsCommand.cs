using MediatR;
using micro_api.Application.Common.Interfaces;
using micro_api.Application.Common.Security;
using micro_api.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoLists.Commands.PurgeTodoLists
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeTodoListsCommand : IRequest
    {
    }

    public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeTodoListsCommand>
    {
        private readonly IUnitOfWork _uow;

        public PurgeTodoListsCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
        {
            _uow.Repository<TodoList>().RemoveRange(await _uow.Repository<TodoList>().GetAllAsync());

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
