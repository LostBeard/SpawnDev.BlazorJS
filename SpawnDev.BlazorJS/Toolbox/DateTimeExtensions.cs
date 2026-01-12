namespace SpawnDev.BlazorJS.Toolbox
{
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime dateTime, bool unspecifiedKindIsUtc)
        {
            if (!unspecifiedKindIsUtc) return dateTime.ToLocalTime();
            switch (dateTime.Kind)
            {
                case DateTimeKind.Unspecified: return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc).ToLocalTime();
                default: return dateTime.ToLocalTime();
            }
        }
        public static DateTime ToUniversalTime(this DateTime dateTime, bool unspecifiedKindIsUtc)
        {
            if (!unspecifiedKindIsUtc) return dateTime.ToUniversalTime();
            switch (dateTime.Kind)
            {
                case DateTimeKind.Unspecified: return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc).ToUniversalTime();
                default: return dateTime.ToUniversalTime();
            }
        }
        /// <summary>
        /// Returns a simplified string representing the date time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToSimpleTime(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var diff = now - dateTime;
            if (diff.TotalMinutes < 1d)
            {
                return $"Just now";
            }
            else if (diff.TotalMinutes < 2d)
            {
                return $"A minute ago";
            }
            else if (diff.TotalMinutes < 60)
            {
                return $"{Math.Floor(diff.TotalMinutes)} minutes ago";
            }
            else if (now.Date == dateTime.Date)
            {
                // today
                return dateTime.ToString("h:mm:ss tt");
            }
            else if ((now - TimeSpan.FromDays(1)).Date == dateTime.Date)
            {
                // yesterday
                return $"{dateTime.ToString("h:mm:ss tt")} Yesterday";
            }
            else if (diff.TotalDays < 7)
            {
                // in the last 7 days
                return dateTime.ToString("ddd");
            }
            else
            {
                // else
                return dateTime.ToString("MMM d yyyy");
            }
        }
        public static double NextSimpleTimeChangeMS(this DateTime dateTime, double padValue = 0)
        {
            return dateTime.NextSimpleTimeChange().TotalMilliseconds + padValue;
        }
        public static TimeSpan NextSimpleTimeChange(this DateTime dateTime)
        {
            var now = DateTime.Now;
            var diff = now - dateTime;
            if (diff.TotalMinutes <= 60)
            {
                // next minute increment
                var nextMinuteIncrement = TimeSpan.FromMinutes(1d - (diff.TotalMinutes - Math.Truncate(diff.TotalMinutes)));
                return nextMinuteIncrement;
            }
            else
            {
                // next day change
                var nextDayChange = (now.Date + TimeSpan.FromDays(1)) - now;
                return nextDayChange;
            }
        }
    }
}
