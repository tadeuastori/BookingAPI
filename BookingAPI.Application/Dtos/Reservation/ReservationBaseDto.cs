using System;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Application.Dtos.Reservation
{
    public class ReservationBaseDto
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
    }
}
