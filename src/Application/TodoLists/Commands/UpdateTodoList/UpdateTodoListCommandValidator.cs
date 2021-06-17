using FluentValidation;
using micro_api.Application.Common.Interfaces;
using micro_api.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTodoListCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string title, CancellationToken cancellationToken)
        {
            var result = await _uow.Repository<TodoList>()
                .FindAsync(l => l.Id != model.Id);

            return result.All(l => l.Title != title);

        }
    }
}
