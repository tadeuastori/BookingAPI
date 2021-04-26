using BookingAPI.Domain.Entities.Base;
using System.Collections.Generic;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Domain.Entities
{
    public class Room : BaseEntity
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public RoomType Type { get; set; }
        public List<Reservation> Bookings { get; set; }
    }
}
