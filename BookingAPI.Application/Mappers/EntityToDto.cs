using AutoMapper;
using BookingAPI.Application.Dtos.Person;
using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Dtos.Room;
using BookingAPI.Domain.Entities;

namespace BookingAPI.Application.Mappers
{
    public class EntityToDto : Profile 
    {
        public EntityToDto()
        {
            CreateMap<Person, PersonSimplifiedDto>();
            
            CreateMap<Reservation, ReservationSimplifiedDto>();

            CreateMap<Room, RoomSimplifiedDto>();
        }
    }
}
