using BookingAPI.Application.Dtos.Reservation;
using BookingAPI.Application.Interfaces;
using BookingAPI.Domain.Entities;
using BookingAPI.Infra.CrossCutting.Infrastructure.ExceptionsMethods;
using BookingAPI.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookingAPI.Services.Api.Controllers
{
    public class ReservationController : ControllerBase<Reservation, ReservationSimplifiedDto>
    {
        private readonly IReservationApplicationService _applicationService;
        #region Attributes

        #endregion

        #region Constructor
        public ReservationController(IReservationApplicationService applicationService) : base(applicationService)
        {
            _applicationService = applicationService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check the availability of a reservation considering the range date
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     HttpGet /Reservation/CheckAvailableAsync
        ///         {URL}/CheckAvailableAsync?checkIn=2021-05-01&checkOut=2021-05-03
        ///     
        /// </remarks>
        /// <param name="checkIn">Start date</param>
        /// <param name="checkOut">End date</param>
        /// <returns>A boolean indicate if a reservation is available</returns>
        /// <response code="200">Returns a boolean indicate if a reservation is available</response>
        /// <response code="422">Returns the error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpGet("CheckAvailableAsync")]
        public async Task<IActionResult> CheckAvailableAsync([FromQuery][Required] DateTime checkIn, [FromQuery][Required] DateTime checkOut)
        {
            try
            {
                var result = await _applicationService.CheckAvailableAsync(checkIn, checkOut);

                return Json(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Search for booking using reservation code
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     HttpPatch /Reservation/SearchBookingByCodeAsync
        ///         {URL}/code?code=A1B2C3
        ///     
        /// </remarks>
        /// <param name="code">Reservation code</param>
        /// <returns>The found Booking</returns>
        /// <response code="200">Returns the found item</response>
        /// <response code="422">Returns the error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpGet("SearchBookingByCodeAsync")]
        public async Task<IActionResult> SearchBookingByCodeAsync([FromQuery][Required] string code)
        {
            try
            {
                var result = await _applicationService.SearchBookingByCode(code);

                return Json(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Get the list of reservations between dates
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     HttpGet /Reservation/GetListReservationsAsync
        ///         {URL}/GetListReservationsAsync?checkIn=2021-05-01checkOut=2021-05-03
        ///     
        /// </remarks>
        /// <param name="checkIn">Start date</param>
        /// <param name="checkOut">End date</param>
        /// <returns>List of reservations</returns>
        /// <response code="200">Returns a list of reservations</response>
        /// <response code="422">Returns the error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpGet("GetListReservationsAsync")]
        public async Task<IActionResult> GetListReservationsAsync([FromQuery][Required] DateTime checkIn, [FromQuery][Required] DateTime checkOut)
        {
            try
            {
                var result = await _applicationService.GetListReservationsAsync(checkIn, checkOut);

                return Json(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Booking a Room in a available period
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Reservation/MakeAsync
        ///     {
        ///         "checkIn": "2021-04-25",
        ///         "checkOut": "2021-04-26",
        ///         "fullName": "John Smith",
        ///         "email": "john.smith@email.ca"
        ///     }
        ///     
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>A newly created Booking</returns>
        /// <response code="200">Success</response>
        /// <response code="201">Returns the Newly created item</response>
        /// <response code="422">Returns the Validation error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpPost("MakeAsync")]
        public async Task<IActionResult> MakeAsync(ReservationCreateDto dto)
        {
            try
            {
                var result = await _applicationService.MakeAsync(dto);

                return Json(result, HttpStatusCode.Created);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Modify a existing reservation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /Reservation/MakeAsync
        ///     {
        ///         "code": "A1B2C3",
        ///         "checkIn": "2021-04-25",
        ///         "checkOut": "2021-04-26"
        ///     }
        ///     
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>A newly created Booking</returns>
        /// <response code="200">Returns the modified item</response>
        /// <response code="422">Returns the error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpPut("ModifyAsync")]
        public async Task<IActionResult> ModifyAsync(ReservationUpdateDto dto)
        {
            try
            {
                var result = await _applicationService.ModifyAsync(dto);

                return Json(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Cancel a reservation with reservation code
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     HttpPatch /Reservation/MakeAsync
        ///         {URL}/code?code=A1B2C3
        ///     
        /// </remarks>
        /// <param name="code">Reservation code</param>
        /// <returns>A boolean indicate if a reservation was canceled</returns>
        /// <response code="200">Returns the boolean item</response>
        /// <response code="422">Returns the error item</response> 
        /// <response code="500">Returns the Internal Server error item</response> 
        [HttpPatch("CancelAsync")]
        public async Task<IActionResult> CancelAsync([FromQuery][Required] string code)
        {
            try
            {
                var result = await _applicationService.CancelAsync(code);

                return Json(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return Json(new { Errors = ex.Errors.Select(x => x.ErrorMessage) }, HttpStatusCode.UnprocessableEntity);
            }
            catch (ValidationDomainException ex)
            {
                return Json(new { Errors = ex.Message }, HttpStatusCode.UnprocessableEntity);
            }
            catch (Exception ex)
            {
                return Json(new { Errors = new string[] { ex.Message } }, HttpStatusCode.InternalServerError);
            }
        }
        #endregion
    }
}
