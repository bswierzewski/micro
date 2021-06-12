using micro_api.Application.Common.Mappings;
using micro_api.Domain.Entities;

namespace micro_api.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
