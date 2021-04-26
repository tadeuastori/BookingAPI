using AutoMapper;
using BookingAPI.Application.Dtos.Room;
using BookingAPI.Application.Interfaces;
using BookingAPI.Application.Services.Base;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Services;

namespace BookingAPI.Application.Services
{
    public class RoomApplicationService : ApplicationServiceBase<Room, RoomSimplifiedDto>, IRoomApplicationService
    {
        #region Attributes
        #endregion

        #region Constructor
        public RoomApplicationService(IMapper mapper, IRoomDomainService service) : base(mapper, service)
        {
        } 
        #endregion
    }
}
