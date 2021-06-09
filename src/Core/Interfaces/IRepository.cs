using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id, List<Expression<Func<TEntity, object>>> includes = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}