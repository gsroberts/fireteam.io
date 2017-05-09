using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fireteam.Common.Extensions
{
    public static class UserIdentityExtensions
    {
        public static TimeZoneInfo GetTimeZoneInfo(this IIdentity user)
        {
            var zoneId = GetPropertyValue<string>(user, "TimeZone");
            return (!string.IsNullOrWhiteSpace(zoneId)) ? TimeZoneInfo.FindSystemTimeZoneById(zoneId) : null; 
        }

        public static string GetDisplayName(this IIdentity user)
        {

            var displayName = GetPropertyValue<string>(user, "DisplayName");
            return (!string.IsNullOrWhiteSpace(displayName)) ? displayName : null;
        }

        private static T GetPropertyValue<T>(IIdentity user, string propName)
        {
            var prop = user.GetType()
                .GetProperties()
                .AsEnumerable()
                .FirstOrDefault(u => u.Name == propName);

            var propValue = prop?.GetValue(user);

            return (T) Convert.ChangeType(propValue, typeof(T));
        }
    }
}
