using BookingAPI.Application.Dtos.Reservation;
using FluentValidation;

namespace BookingAPI.Application.Validations
{
    public class ReservationBaseDtoValidator<TEntityDto> : AbstractValidator<TEntityDto> where TEntityDto: ReservationBaseDto 
    {
        public ReservationBaseDtoValidator()
        {
            RuleFor(r => r.CheckIn)
                .NotNull()
                .NotEmpty()
                .WithMessage("Check-In does not be null or empty");

            RuleFor(r => r.CheckOut)
                .NotNull()
                .NotEmpty()
                .WithMessage("Check-Out does not be null or empty");

            RuleFor(x => x)
                .Custom((dto, context) => { 
                    if (dto.CheckIn > dto.CheckOut || dto.CheckOut < dto.CheckIn)
                    {
                        context.AddFailure("Check the range date");
                    }
                });
        }
    }
}
