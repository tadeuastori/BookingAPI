using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities.Base;

namespace BookingAPI.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid id, bool getDeleted = false);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, string includeProps = null);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, string includeProps = null);
    }
}
