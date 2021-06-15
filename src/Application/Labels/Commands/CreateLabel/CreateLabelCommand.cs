using MediatR;
using micro_api.Domain.Enums;

namespace micro_api.Application.Labels.Commands.CreateLabel
{
    public class CreateLabelCommand : IRequest
    {
        public string Name { get; set; }
        public AddressType LabelType { get; set; }
    }
}
