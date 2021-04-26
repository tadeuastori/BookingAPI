using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Application.Dtos.Reservation
{

    public class ReservationUpdateDto : ReservationBaseDto
    {
        [Required]
        public string Code { get; set; }
    }
}
