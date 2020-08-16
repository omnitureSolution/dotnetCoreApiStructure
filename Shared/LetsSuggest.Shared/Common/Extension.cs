using System;

namespace LetsSuggest.Shared.Common
{
    public static class Extension
    {
        public static DateTime UtcDate(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            return dateTime.ToUniversalTime();
        }
        public static DateTime? UtcDate(this DateTime? dateTime)
        {
            if (dateTime?.Kind == DateTimeKind.Unspecified)
                dateTime = DateTime.SpecifyKind(Convert.ToDateTime(dateTime), DateTimeKind.Utc);
            return dateTime?.ToUniversalTime();
        }
    }
}
