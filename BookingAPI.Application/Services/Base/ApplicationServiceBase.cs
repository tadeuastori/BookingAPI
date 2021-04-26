using System.Threading.Tasks;
using AutoMapper;
using BookingAPI.Application.Dtos.Base;
using BookingAPI.Application.Interfaces.Base;
using BookingAPI.Domain.Entities.Base;
using BookingAPI.Domain.Interfaces.Services;

namespace BookingAPI.Application.Services.Base
{
    public class ApplicationServiceBase<TEntity, TEntityDto> : IApplicationServiceBase<TEntity, TEntityDto> 
        where TEntity : BaseEntity 
        where TEntityDto : BaseDto
    {
        #region Attributes
        protected readonly IMapper _mapper;
        protected readonly IDomainServiceBase<TEntity> _baseService;
        #endregion

        #region Constructor
        public ApplicationServiceBase(IMapper mapper, IDomainServiceBase<TEntity> service) : base()
        {
            _mapper = mapper;
            _baseService = service;
        }
        #endregion

        #region Public Methods
        public virtual async Task<TEntityDto> CreateAsync(TEntityDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            var createdEntity = await _baseService.CreateAsync(entity);

            return _mapper.Map<TEntityDto>(createdEntity);
        }

        public virtual async Task<TEntityDto> UpdateAsync(TEntityDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            var updatedEntity = await _baseService.UpdateAsync(entity);

            return _mapper.Map<TEntityDto>(updatedEntity);
        }
        #endregion

    }
}
