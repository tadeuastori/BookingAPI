using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Interfaces.Base;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Application.Interfaces
{
    public interface IReservationApplicationService : IApplicationServiceBase<Reservation, ReservationSimplifiedDto>
    {
        /// <summary>
        /// Check if has any room available in the between dates
        /// </summary>
        /// <param name="startDay">Start Day</param>
        /// <param name="endDay">End Day</param>
        /// <returns>True: Available | False: Unvailable</returns>
        Task<bool> CheckAvailableAsync(DateTime startDay, DateTime endDay);

        /// <summary>
        /// Modify a reservation
        /// </summary>
        /// <param name="ReservationSimplifiedDto">Reservation Entity to modify</param>
        /// <returns>Reservation modified</returns>
        Task<ReservationSimplifiedDto> ModifyAsync(ReservationUpdateDto ReservationSimplifiedDto);

        /// <summary>
        /// Cancel a reservation by code
        /// </summary>
        /// <param name="code">Reservation code</param>
        /// <returns>True: Cancelled | False: Not Cancelled</returns>
        Task<bool> CancelAsync(string code);

        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="reservation">New Reservation Entity</param>
        /// <returns>Reservation created</returns>
        Task<ReservationSimplifiedDto> MakeAsync(ReservationCreateDto reservation);

        /// <summary>
        /// Search for reservation by Code
        /// </summary>
        /// <param name="code">Booking Code</param>
        /// <returns>Reservation</returns>
        Task<ReservationSimplifiedDto> SearchBookingByCode(string code);

        /// <summary>
        /// Get a list of reservations between dates
        /// </summary>
        /// <param name="startDay">Start Date</param>
        /// <param name="endDay">End Dates</param>
        /// <returns>List of reservations</returns>
        Task<List<ReservationSimplifiedDto>> GetListReservationsAsync(DateTime startDay, DateTime endDay);
    }
}
