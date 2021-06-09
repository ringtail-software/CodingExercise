using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment.API.Helpers
{
    public static class DateTimeExtensions
    {
        public static string GetTerm(this DateTime dateTime)
        {
            var totalDays = (DateTime.Now - dateTime).TotalDays;

            if (totalDays > 365)
            {
                return "Long";
            }
            return "Short";
        }
    }
}