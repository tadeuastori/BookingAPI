using BookingAPI.Application.Dtos.Base;

namespace BookingAPI.Application.Dtos.Room
{
    public class RoomSimplifiedDto : BaseDto
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
