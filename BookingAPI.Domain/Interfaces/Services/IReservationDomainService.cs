using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Interfaces.Services
{
    public interface IReservationDomainService : IDomainServiceBase<Reservation>
    {
        /// <summary>
        /// Check if has any room available in the between dates
        /// </summary>
        /// <param name="startDay">Start Day</param>
        /// <param name="endDay">End Day</param>
        /// <returns>True: Available | False: Unvailable</returns>
        Task<bool> CheckAvailableAsync(DateTime startDay, DateTime endDay);

        /// <summary>
        /// Cancel a reservation by Reservation Id
        /// </summary>
        /// <param name="reservation">Canceled Reservation Entity</param>
        /// <returns>Canceled Reservation Entity</returns>
        Task<Reservation> CancelAsync(Reservation reservation);

        /// <summary>
        /// Get Reservation By code 
        /// </summary>
        /// <param name="code">Reservation code</param>
        /// <returns>Reservation Entity</returns>
        Task<Reservation> GetByCodeAsync(string code);

        /// <summary>
        /// Get a list of reservations between dates
        /// </summary>
        /// <param name="startDay">Start Date</param>
        /// <param name="endDay">End Dates</param>
        /// <returns>List of reservations</returns>
        Task<List<Reservation>> GetListReservation(DateTime startDay, DateTime endDay);
    }
}
