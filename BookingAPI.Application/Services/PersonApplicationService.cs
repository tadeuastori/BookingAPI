using AutoMapper;
using BookingAPI.Application.Dtos.Room;
using BookingAPI.Application.Interfaces;
using BookingAPI.Application.Services.Base;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Services;

namespace BookingAPI.Application.Services
{
    public class PersonApplicationService : ApplicationServiceBase<Person, RoomSimplifiedDto>, IPersonApplicationService
    {
        #region Attributes
        #endregion

        #region Constructor
        public PersonApplicationService(IMapper mapper, IPersonDomainService service) : base(mapper, service)
        {
        } 
        #endregion
    }
}
