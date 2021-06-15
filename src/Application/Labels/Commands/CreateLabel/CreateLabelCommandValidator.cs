using FluentValidation;
using micro_api.Domain.Enums;

namespace micro_api.Application.Labels.Commands.CreateLabel
{
    public class CreateLabelCommandValidator : AbstractValidator<CreateLabelCommand>
    {
        public CreateLabelCommandValidator()
        {
            RuleFor(x => x.LabelType)
                .NotNull()
                .IsInEnum();
        }
    }
}
