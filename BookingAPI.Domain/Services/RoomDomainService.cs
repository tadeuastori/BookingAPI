using System;
using System.Threading.Tasks;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Domain.Interfaces.Services;
using BookingAPI.Domain.Services.Base;

namespace BookingAPI.Domain.Services
{
    public class RoomDomainService : DomainServiceBase<Room>, IRoomDomainService
    {
        #region Attributes
        protected readonly IRoomRepository _repository; 
        #endregion

        #region Constructors
        public RoomDomainService(IRoomRepository repository) : base(repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public async Task<Room> GetAvailableAsync(DateTime start, DateTime end, string reservationCode)
        {
            return await _repository.GetAvailableAsync(start, end, reservationCode);
        }
        #endregion
    }
}
