using BookingAPI.Test.ResultObjects.BaseObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAPI.Test.ResultObjects
{
    public class PersonSimplified : Base
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
