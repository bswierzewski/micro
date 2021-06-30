using micro_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace micro_api.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Component> Components { get; set; }

        DbSet<Device> Devices { get; set; }

        DbSet<Kind> Kinds { get; set; }

        DbSet<Label> Labels { get; set; }

        DbSet<Version> Versions { get; set; }

        DbSet<VersionData> VersionsData { get; set; }

        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}