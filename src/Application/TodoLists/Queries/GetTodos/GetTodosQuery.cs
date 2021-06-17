using AutoMapper;
using MediatR;
using micro_api.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.TodoLists.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<TodosVm>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
