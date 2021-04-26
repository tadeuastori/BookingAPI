using System;

namespace BookingAPI.Infra.CrossCutting.Infrastructure.ExtensionMethods
{
    public static partial class ExtensionMethod
    {
        public static DateTime StartOfDay(this DateTime date)
        {
            return date.Date;
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddSeconds(-1);
        }
    }
}
