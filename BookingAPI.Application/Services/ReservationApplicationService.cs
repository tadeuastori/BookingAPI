using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Interfaces;
using BookingAPI.Application.Services.Base;
using BookingAPI.Application.Validation;
using BookingAPI.Application.Validations;
using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Interfaces.Services;
using BookingAPI.Infra.CrossCutting.Infrastructure.ExceptionsMethods;
using FluentValidation;
using static BookingAPI.Domain.Enums.Enumerators;

namespace BookingAPI.Application.Services
{
    public class ReservationApplicationService : ApplicationServiceBase<Reservation, ReservationSimplifiedDto>, IReservationApplicationService
    {
        #region Attributes
        private readonly IReservationDomainService _domainService;
        #endregion

        #region Constructors
        public ReservationApplicationService(IMapper mapper, IReservationDomainService service) : base(mapper, service)
        {
            _domainService = service;
        }
        #endregion

        #region Public Methods
        public async Task<bool> CancelAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new Exception("Empty Code");

            var entity = await _domainService.GetByCodeAsync(code);

            if (entity == null) throw new Exception("Reservation does not found");

            entity = await _domainService.CancelAsync(entity);

            return entity.Status == ReservationStatus.Canceled;
        }

        public async Task<ReservationSimplifiedDto> SearchBookingByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ValidationDomainException("Empty Code");

            var entity = await _domainService.GetByCodeAsync(code);

            if (entity == null) throw new Exception("Reservation does not found");

            return _mapper.Map<ReservationSimplifiedDto>(entity);
        }

        public async Task<bool> CheckAvailableAsync(DateTime startDay, DateTime endDay)
        {
            var dto = new ReservationBaseDto { CheckIn = startDay, CheckOut = endDay };

            var validator = new ReservationBaseDtoValidator<ReservationBaseDto>();
            await validator.ValidateAndThrowAsync(dto);

            return await _domainService.CheckAvailableAsync(startDay, endDay);
        }

        public async Task<List<ReservationSimplifiedDto>> GetListReservationsAsync(DateTime startDay, DateTime endDay)
        {
            var dto = new ReservationBaseDto { CheckIn = startDay, CheckOut = endDay };

            var validator = new ReservationBaseDtoValidator<ReservationBaseDto>();
            await validator.ValidateAndThrowAsync(dto);

            var entity = await _domainService.GetListReservation(startDay, endDay);

            return _mapper.Map<List<ReservationSimplifiedDto>>(entity);
        }

        public async Task<ReservationSimplifiedDto> MakeAsync(ReservationCreateDto dto)
        {
            var validator = new ReservationCreateDtoValidator();
            await validator.ValidateAndThrowAsync(dto);

            var entity = _mapper.Map<Reservation>(dto);
            entity.Person = _mapper.Map<Person>(dto);

            entity = await _domainService.CreateAsync(entity);

            return _mapper.Map<ReservationSimplifiedDto>(entity);
        }

        public async Task<ReservationSimplifiedDto> ModifyAsync(ReservationUpdateDto dto)
        {
            var validator = new ReservationUpdateDtoValidator();
            await validator.ValidateAndThrowAsync(dto);

            var originalEntity = await _domainService.GetByCodeAsync(dto.Code);

            if (originalEntity == null) throw new Exception("Reservations does not found");

            var entity = _mapper.Map(dto, originalEntity);

            entity = await _domainService.UpdateAsync(entity);

            return _mapper.Map<ReservationSimplifiedDto>(entity);
        }
        #endregion
    }
}
