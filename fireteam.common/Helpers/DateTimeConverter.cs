using System;
using System.Collections.Generic;
using System.Text;

namespace Fireteam.Common.Helpers
{
    /// <summary>
    /// Provides a converter for converting UTC and local times
    /// </summary>
    public static class DateTimeConverter
    {
        /// <summary>
        /// Get a TimeZoneInfo instance that represents the zone ID
        /// passed in
        /// </summary>
        /// <param name="zoneId">The TimeZoneInfo.Id value to retrieve an instance for</param>
        /// <returns></returns>
        private static TimeZoneInfo GetTimeZoneInfo(string zoneId)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(zoneId);
        }

        /// <summary>
        /// Get the UTC time passed in as a localized DateTime instance
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTime GetLocalTime(DateTime time, string timeZone)
        {
            return TimeZoneInfo.ConvertTime(time, GetTimeZoneInfo(timeZone));
        }
    }
}
