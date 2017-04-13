using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Helpers
{
    public static class DateTimeConverter
    {
        private static TimeZoneInfo GetTimeZoneInfo(string zoneId)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(zoneId);
        }

        public static DateTime GetLocalTime(DateTime time, string timeZone)
        {
            return TimeZoneInfo.ConvertTime(time, GetTimeZoneInfo(timeZone));
        }
    }
}
