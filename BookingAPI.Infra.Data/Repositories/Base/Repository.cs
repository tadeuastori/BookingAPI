using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities.Base;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Infra.Data.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Attributes
        protected readonly BookingContext _context; 
        #endregion

        #region Constructors
        public Repository(BookingContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        public async Task<TEntity> GetByIdAsync(Guid id, bool getDeleted = false)
        {
            if (getDeleted)
                return await _context.Set<TEntity>().FindAsync(id);
            else
                return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id && x.Active && x.DeletedAt == null);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.Active = true;

            var result = await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _context.Set<TEntity>().Update(entity);
            entry.Property(x => x.CreatedAt).IsModified = false;
            entry.Property(x => x.Id).IsModified = false;

            entity = entry.Entity;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, string includeProps = null)
        {
            return await GetQueryable(filter, includeProps).ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, string includeProps = null)
        {
            return await GetQueryable(filter, includeProps).FirstOrDefaultAsync();
        }
        #endregion

        #region Private Methods
        private IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter = null, string includeProps = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProps))
            {
                query = includeProps.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (q, p) => q.Include(p));
            }

            return query;
        }
        #endregion
    }
}
