using micro_api.Domain.Common;
using System;
using System.Threading.Tasks;

namespace micro_api.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
