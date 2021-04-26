using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities.Base;

namespace BookingAPI.Domain.Interfaces.Services
{
    public interface IDomainServiceBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
