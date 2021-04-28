using BookingAPI.Test.ResultObjects.BaseObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Test.ResultObjects
{
    public class RoomSimplified : Base
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
