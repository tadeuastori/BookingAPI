using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Application.Dtos.Reservation
{
    public class ReservationCreateDto : ReservationBaseDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
