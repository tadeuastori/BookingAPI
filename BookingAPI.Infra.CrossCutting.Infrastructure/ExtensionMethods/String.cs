﻿using System;
using System.Linq;

namespace BookingAPI.Infra.CrossCutting.Infrastructure.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
