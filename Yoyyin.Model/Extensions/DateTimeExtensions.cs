using System;
using System.Globalization;

namespace Yoyyin.Model.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Format date as in Trinity, Idag klockan...
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToFormattedString(this DateTime dateTime)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1)
            {
                return "Precis nu";
            }
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "en sekund sedan" : ts.Seconds + " sekunder sen";
            }
            if (delta < 120)
            {
                return "en minut sedan";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minuter sen";
            }
            if (delta < 5400) // 90 * 60
            {
                return "en timme sen";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " timmar sen";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "igår";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " dagar sen";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "en månad sedan" : months + " måndader sedan";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "ett år sedan" : years + " år sedan";
        }

        public static string ToFormattedString(this DateTime? dateTime)
        {
            if (dateTime == null) return string.Empty;

            var notNullaleDateTime = (DateTime)dateTime;
            return notNullaleDateTime.ToFormattedString();
        }
    }
}
