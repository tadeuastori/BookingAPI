using System.Net;
using BookingAPI.Application.Dtos.Base;
using BookingAPI.Application.Interfaces.Base;
using BookingAPI.Domain.Entities.Base;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Services.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class ControllerBase<TEntity, TEntityDto> : ControllerBase
        where TEntity: BaseEntity
        where TEntityDto: BaseDto
    {
        #region Attributes
        private readonly IApplicationServiceBase<TEntity, TEntityDto> _service; 
        #endregion

        #region Constructors
        public ControllerBase(IApplicationServiceBase<TEntity, TEntityDto> service)
        {
            _service = service;
        }
        #endregion

        #region Methods
        protected JsonResult Json(object obj, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new JsonResult(obj)
            {
                StatusCode = (int)statusCode
            };
        }
        #endregion
    }
}
