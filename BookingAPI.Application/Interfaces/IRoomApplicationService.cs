using BookingAPI.Application.Dtos.Room;
using BookingAPI.Application.Interfaces.Base;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Application.Interfaces
{
    public interface IRoomApplicationService : IApplicationServiceBase<Room, RoomSimplifiedDto>
    { 
    }
}
