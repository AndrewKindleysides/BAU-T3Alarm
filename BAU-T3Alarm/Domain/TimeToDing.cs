using System;

namespace Domain
{
    public class TimeToDing
    {
        public bool CheckTime(DateTime now)
        {
            if (InBusinessHours(now) && NotAWeekend(now) && NotNationalHoliday(now))
                return true;
            return false;
        }

        private bool NotNationalHoliday(DateTime now)
        {
            return NotChristmasDay(now) && NotBoxingDay(now) && NotNewYearsDay(now);
        }

        private bool NotBoxingDay(DateTime now)
        {
            return !(now.Day == 26 && now.Month == 12);
        }

        private bool NotNewYearsDay(DateTime now)
        {
            return !(now.Day == 1 && now.Month == 1);
        }

        private static bool NotChristmasDay(DateTime now)
        {
            return !(now.Day == 25 && now.Month == 12);
        }

        private bool NotAWeekend(DateTime now)
        {
            return now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday;
        }

        private static bool InBusinessHours(DateTime now)
        {
            return now.Hour < 17 && now.Hour > 7;
        }
    }
}