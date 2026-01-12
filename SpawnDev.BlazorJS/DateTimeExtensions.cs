namespace SpawnDev.BlazorJS
{
    /// <summary>
    /// Adds Unix epoch related extension methods to dateTime nad long<br />
    /// Compatible with Javascript's new Date().getTime()
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a DateTime to an epoch long<br />
        /// NOTE: .Net treats a DateTime with a Kind property value of DateTimeKind.Unspecified as local time<br />
        /// .Net, by default, deserializes to a DateTime with Kind of DateTimeKind.Unspecified
        /// </summary>
        /// <param name="oDate"></param>
        /// <returns></returns>
        public static long GetEpochTime(this DateTime oDate)
        {
            var oOrigin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan oDiff = oDate.ToUniversalTime() - oOrigin;
            return (long)Math.Floor(oDiff.TotalMilliseconds);
        }
        /// <summary>
        /// Converts an epoch long to a DateTime
        /// </summary>
        /// <param name="msSince19700101Utc"></param>
        /// <param name="toLocal"></param>
        /// <returns></returns>
        public static DateTime EpochTimeToDateTime(this long msSince19700101Utc, bool toLocal = true)
        {
            var oOrigin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            oOrigin = oOrigin.AddMilliseconds(msSince19700101Utc);
            if (toLocal) return oOrigin.ToLocalTime();
            return oOrigin;
        }
    }
}
