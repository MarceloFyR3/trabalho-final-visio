using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Final.Visual.Dominio.Interface.Repository;
using Trabalho.Final.Visual.Infra.Context;

namespace Trabalho.Final.Visual.Infra.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext) : base()
        {
            _dbContext = dbContext;
        }

        public Task Create(TEntity entity)
        {
            return Task.Run(() =>
            {
                _ = _dbContext.Set<TEntity>().AddAsync(entity); ;
            });            
        }

        public Task<TEntity> CreateItem(TEntity entity)
        {
            return Task.Run(() =>
            {
                EntityEntry<TEntity> result = _dbContext.Set<TEntity>().Add(entity);
                _dbContext.SaveChanges();
                return result.Entity;
            });
        }

        public Task Delete(TKey id)
        {
            return Task.Run(() =>
            {
                var entity = Get(id);
                if (entity != null) _ = _dbContext.Set<TEntity>().Remove(entity.Result);
                _dbContext.SaveChanges();
            });
        }

        public Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return Task.FromResult(query.FirstOrDefault());
        }

        public Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            IEnumerable<TEntity> @return = query.ToList();

            return Task.FromResult(@return);
        }

        public Task<TEntity> Get(TKey id)
        {
            var @return = _dbContext.Set<TEntity>().Find(id);
            return Task.FromResult(@return);
        }

        public Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _dbContext.Set<TEntity>()
               .AsQueryable();

            if (include != null)
                query = include(query);

            IEnumerable<TEntity> @return = query.ToList();

            return Task.FromResult(@return);
        }

    }
}
