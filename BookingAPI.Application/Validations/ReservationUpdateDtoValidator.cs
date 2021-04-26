using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Validations;
using FluentValidation;

namespace BookingAPI.Application.Validation
{
    public class ReservationUpdateDtoValidator : ReservationBaseDtoValidator<ReservationUpdateDto>
    {
        public ReservationUpdateDtoValidator()
        {
            RuleFor(r => r.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code does not be null or empty");
        }
    }
}
