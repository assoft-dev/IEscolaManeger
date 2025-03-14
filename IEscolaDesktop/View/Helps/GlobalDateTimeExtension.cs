using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaDesktop.View.Helps
{
    public static class GlobalDateTimeExtension
    {
        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.StartOfMonth().AddMonths(1).AddSeconds(-1);
        }
    }
}
