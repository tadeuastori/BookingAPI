using System;
using BookingAPI.Domain.Entities.Base;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public string ReservationCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
