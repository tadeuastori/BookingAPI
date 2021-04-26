using System.Collections.Generic;
using BookingAPI.Domain.Entities.Base;

namespace BookingAPI.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Reservation> Bookings { get; set; }
    }
}
