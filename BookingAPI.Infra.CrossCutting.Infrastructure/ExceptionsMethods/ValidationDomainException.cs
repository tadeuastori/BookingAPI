using System;
using System.Collections.Generic;

namespace BookingAPI.Infra.CrossCutting.Infrastructure.ExceptionsMethods
{
    public class ValidationDomainException : Exception
    {
        public ValidationDomainException(string message) : base(message)
        {
        }

        public ValidationDomainException(Exception ex) : base(ex.Message)
        {
        }

    }
}
