using micro_api.Application.Common.Exceptions;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IUnitOfWork _context;

        public UpdateTodoItemCommandHandler(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Repository<TodoItem>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            entity.Title = request.Title;
            entity.Done = request.Done;

            await _context.Complete();

            return Unit.Value;
        }
    }
}
