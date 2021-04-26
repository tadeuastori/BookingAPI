using System;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetAvailableAsync(DateTime startDay, DateTime endDay, string reservationCode = null);
    }
}
