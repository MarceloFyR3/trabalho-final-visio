using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Trabalho.Final.Visual.Dominio.Interface.Repository
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        #region IGenericRepository Members

        Task<TEntity> Get(TKey id);       

        Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task Create(TEntity entity);
        Task<TEntity> CreateItem(TEntity entity);
        Task Delete(TKey id);

        #endregion
    }
}
