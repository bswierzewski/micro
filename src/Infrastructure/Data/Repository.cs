using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly StoreContext _context;

        public Repository(StoreContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetById(int id, List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null && includes.Any())
            {
                includes.ToList().ForEach(includeProperty =>
                {
                    query = query.Include(includeProperty);
                });
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includeProperties = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                includeProperties.ToList().ForEach(includeProperty =>
                {
                    query = query.Include(includeProperty);
                });
            }

            return await query.ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async void Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }
    }
}