using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionExtensions
{
    public static class DateTimeExtensions
    {

        public static bool HasAgeXAtDayY(this DateTime date, int x, DateTime y)
        {
            var xthBirthday = date.AddYears(x);
            return xthBirthday <= y;
        }

        public static int GetAgeAtDayX(this DateTime gebDat, DateTime dayX)
        {
            int alter = (dayX.Year - gebDat.Year);
            return gebDat.AddYears(alter) > dayX ? --alter : alter;
        }

        public static int GetMonthsUntil(this DateTime erstZulassung, DateTime letzteZulassung) =>  letzteZulassung.Year * 12
                                                                                                    + letzteZulassung.Month
                                                                                                    - erstZulassung.Year * 12
                                                                                                    - erstZulassung.Month;

    }
}
