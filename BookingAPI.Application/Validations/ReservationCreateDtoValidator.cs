using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Validations;
using FluentValidation;

namespace BookingAPI.Application.Validation
{
    public class ReservationCreateDtoValidator : ReservationBaseDtoValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email does not be null or empty");
        }
    }
}
