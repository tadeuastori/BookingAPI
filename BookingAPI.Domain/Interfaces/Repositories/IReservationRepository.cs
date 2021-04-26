using System.Threading.Tasks;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Domain.Interfaces.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        /// <summary>
        /// Get Reservation By Reservation Code 
        /// </summary>
        /// <param name="reservationCode">Reservation Code</param>
        /// <param name="includeProps">Include relational entity</param>
        /// <returns>Reservation Entity</returns>
        Task<Reservation> GetByCodeAsync(string reservationCode, string includeProps = null);
    }
}
