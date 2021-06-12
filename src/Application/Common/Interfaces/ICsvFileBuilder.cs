using micro_api.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace micro_api.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
