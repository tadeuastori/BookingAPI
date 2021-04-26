using BookingAPI.Application.Dtos.Base;

namespace BookingAPI.Application.Dtos.Person
{
    public class PersonSimplifiedDto : BaseDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
