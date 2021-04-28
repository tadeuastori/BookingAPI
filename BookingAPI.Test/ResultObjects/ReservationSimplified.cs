using BookingAPI.Test.ResultObjects.BaseObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Test.ResultObjects
{
    public class ReservationSimplified : Base
    {
        public string ReservationCode { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Status { get; set; }
        public PersonSimplified Person { get; set; }
        public RoomSimplified Room { get; set; }
    }
}
