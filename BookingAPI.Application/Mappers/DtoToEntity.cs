using AutoMapper;
using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Application.Mappers
{
    public class DtoToEntity : Profile 
    {
        public DtoToEntity()
        {
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<ReservationCreateDto, Person>();
            CreateMap<ReservationUpdateDto, Reservation>()
                .ForMember(target => target.ReservationCode, action => action.Ignore());
        }
    }
}
