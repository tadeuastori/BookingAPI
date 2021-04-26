using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Repositories;
using BookingAPI.Domain.Interfaces.Services;
using BookingAPI.Domain.Services.Base;
using System;
using static BookingAPI.Domain.Enums.Enumerators;
using BookingAPI.Infra.CrossCutting.Infrastructure.ExtensionMethods;
using System.Threading.Tasks;
using BookingAPI.Infra.CrossCutting.Infrastructure.ExceptionsMethods;
using System.Collections.Generic;

namespace BookingAPI.Domain.Services
{
    public class ReservationDomainService : DomainServiceBase<Reservation>, IReservationDomainService
    {
        #region Attributes
        protected readonly IReservationRepository _repository;
        private readonly IRoomDomainService _roomService;
        private readonly IPersonDomainService _personService;
        private const string invalidReservationPeriodMessage = "Range of date is not allowed.";
        #endregion

        #region Constructor
        public ReservationDomainService(IReservationRepository repository, IRoomDomainService roomService, IPersonDomainService personService) : base(repository)
        {
            _repository = repository;
            _roomService = roomService;
            _personService = personService;
        }
        #endregion

        #region Public Methods
        public async Task<Reservation> CancelAsync(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Canceled;

            return await _repository.UpdateAsync(reservation);
        }

        public async Task<bool> CheckAvailableAsync(DateTime startDay, DateTime endDay)
        {
            if (!ValidadeReservation(new Reservation {CheckIn = startDay, CheckOut = endDay })) throw new ValidationDomainException(invalidReservationPeriodMessage);

            var room = await _roomService.GetAvailableAsync(startDay, endDay);
            return room != null;
        }

        public async Task<List<Reservation>> GetListReservation(DateTime startDay, DateTime endDay)
        {
            return await _repository.GetListAsync(x => x.CheckIn >= startDay.StartOfDay() && x.CheckOut <= endDay.EndOfDay(), "Room,Person");
        }

        public async Task<Reservation> GetByCodeAsync(string code)
        {
            return await _repository.GetByCodeAsync(code, "Room,Person");
        }

        public override async Task<Reservation> CreateAsync(Reservation reservation)
        {
            if (!ValidadeReservation(reservation)) throw new ValidationDomainException(invalidReservationPeriodMessage);

            var room = await GetAvailableRoomAsync(reservation);
            var person = await GetPeopleAsync(reservation);

            reservation.Room = room;
            reservation.Person = person;
            reservation.Status = ReservationStatus.Reserved;
            reservation.CheckIn = reservation.CheckIn.StartOfDay();
            reservation.CheckOut = reservation.CheckOut.EndOfDay();
            reservation.ReservationCode = ExtensionMethods.RandomString(6);

            return await base.CreateAsync(reservation);
        }

        public override async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            if (!ValidadeReservation(reservation)) throw new ValidationDomainException(invalidReservationPeriodMessage);

            var room = await GetAvailableRoomAsync(reservation, true);

            reservation.Room = room;
            reservation.CheckIn = reservation.CheckIn.StartOfDay();
            reservation.CheckOut = reservation.CheckOut.EndOfDay();

            return await base.UpdateAsync(reservation);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validate the reservation date range
        /// </summary>
        /// <param name="reservation">Reservation Entity</param>
        /// <returns>True: Is Valid | False: Not Valid</returns>
        private static bool ValidadeReservation(Reservation reservation)
        {
            return reservation.CheckIn.StartOfDay() >= DateTime.Now.AddDays(1).StartOfDay() && //Start reservation at least next day of booking
                   (reservation.CheckOut.EndOfDay() - reservation.CheckIn.StartOfDay()) <= TimeSpan.FromDays(3) && //Stay period can't be longer than 3 days
                   reservation.CheckIn.StartOfDay() <= DateTime.Now.AddDays(30).StartOfDay(); //Can't be reserved more than 30 days in advanced;
        }

        /// <summary>
        /// Check if room is available
        /// </summary>
        /// <param name="reservation">Reservation Entity</param>
        /// <param name="isUpdating">True: From Update | False: From Create</param>
        /// <returns>Room Entity</returns>
        private async Task<Room> GetAvailableRoomAsync(Reservation reservation, bool isUpdating = false)
        {
            var code = isUpdating ? reservation.ReservationCode : null;
            var room = await _roomService.GetAvailableAsync(reservation.CheckIn, reservation.CheckOut, code);

            if (room == null) throw new ValidationDomainException("Room Unavailable");

            return room;
        }

        private async Task<Person> GetPeopleAsync(Reservation reservation)
        {
            var person = await _personService.GetPeopleAsync(reservation.Person.Email);

            if (person == null) return reservation.Person;

            return person;
        }
        #endregion
    }
}
