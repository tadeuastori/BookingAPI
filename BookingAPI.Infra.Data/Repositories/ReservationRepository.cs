using System.Threading.Tasks;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Infra.Data.Context;
using BookingAPI.Infra.Data.Repositories.Base;

namespace BookingAPI.Infra.Data.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        #region Constructor
        public ReservationRepository(BookingContext context) : base(context)
        {
        }
        #endregion

        #region Public Methods
        public async Task<Reservation> GetByCodeAsync(string reservationCode, string includeProps = null)
        {
            return await GetFirstAsync(x => x.ReservationCode == reservationCode, includeProps);
        }
        #endregion
    }
}
