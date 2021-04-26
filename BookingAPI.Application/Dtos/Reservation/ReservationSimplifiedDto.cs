using System;
using BookingAPI.Application.Dtos.Base;
using BookingAPI.Application.Dtos.Person;
using BookingAPI.Application.Dtos.Room;

namespace BookingAPI.Application.Dtos.Reservation
{
    public class ReservationSimplifiedDto : BaseDto
    {
        public string ReservationCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Status { get; set; }
        public PersonSimplifiedDto Person { get; set; }
        public RoomSimplifiedDto Room { get; set; }
    }
}
