using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities.Base;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Domain.Interfaces.Services;

namespace BookingAPI.Domain.Services.Base
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity: BaseEntity
    {
        #region Attributes
        protected readonly IRepository<TEntity> _baseRepository; 
        #endregion

        #region Constructors
        public DomainServiceBase(IRepository<TEntity> repository)
        {
            _baseRepository = repository;
        }
        #endregion

        #region Public Methods
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await _baseRepository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _baseRepository.GetListAsync(filter);
        }
        #endregion
    }
}
