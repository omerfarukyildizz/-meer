using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbk.Core.Utilities.Uniq
{
    public static class DateHelper
    {
        public static string ConvertToSqlDateCondition(string dateInput)
        {
            if (string.IsNullOrWhiteSpace(dateInput))
            {
                return string.Empty; 
            }

            if (dateInput.Contains(" to "))
            {
                var dates = dateInput.Split(" to ", StringSplitOptions.RemoveEmptyEntries);
                if (dates.Length != 2)
                {
                    return string.Empty; 
                }

                var startDate = dates[0].Trim();
                var endDate = dates[1].Trim();
                return $@"BETWEEN '{startDate}' AND '{endDate}'";
            }

            return $@"= '{dateInput.Trim()}'";
        }
    }
}
