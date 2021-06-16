using micro_api.Domain.Common;
using micro_api.Domain.ValueObjects;
using System.Collections.Generic;

namespace micro_api.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
