using System;
using System.Linq;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Infra.CrossCutting.Infrastructure.ExtensionMethods;
using BookingAPI.Infra.Data.Context;
using BookingAPI.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Infra.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        #region Constructors
        public RoomRepository(BookingContext context) : base(context)
        {
        }
        #endregion

        #region Public Methods
        public async Task<Room> GetAvailableAsync(DateTime startDay, DateTime endDay, string reservationCode = null)
        {
            return await _context.Rooms
                .Include(r => r.Bookings)
                .FirstOrDefaultAsync(a => a.Bookings == null || a.Bookings.Any(a => a.CheckIn < endDay.EndOfDay() 
                                                                            && startDay.StartOfDay() < a.CheckOut 
                                                                            && a.Status == ReservationStatus.Reserved 
                                                                            && a.Active 
                                                                            && (reservationCode != null ? a.ReservationCode != reservationCode : true)
                                                                        ) == false);
        }
        #endregion
    }
}
