using System.Threading.Tasks;
using BookingAPI.Application.Dtos.Base;
using BookingAPI.Domain.Entities.Base;

namespace BookingAPI.Application.Interfaces.Base
{
    public interface IApplicationServiceBase<TEntity, TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
    {
        Task<TEntityDto> CreateAsync(TEntityDto dto);
        Task<TEntityDto> UpdateAsync(TEntityDto dto);
    }
}
