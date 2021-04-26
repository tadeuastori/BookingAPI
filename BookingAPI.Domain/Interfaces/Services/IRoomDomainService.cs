using System;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Interfaces.Services
{
    public interface IRoomDomainService : IDomainServiceBase<Room>
    {
        Task<Room> GetAvailableAsync(DateTime start, DateTime end, string reservationCode = null);
    }
}
