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
            //int days = DateTime.Now.DayOfYear - dateTime.DayOfYear;

            //switch (days)
            //{
            //    case 0:
            //        return "Idag klockan " + dateTime.ToString("HH:mm");
            //    case 1:
            //        return "Igår klockan " + dateTime.ToString("HH:mm");
            //    default:
            //        var cultureInfo = new CultureInfo("sv-SE");
            //        return dateTime.ToString("dddd dd MMMM yyyy HH:mm", cultureInfo);
            //}
            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1)
            {
                return "Precis nu";
            }
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }

        public static string ToFormattedString(this DateTime? dateTime)
        {
            if (dateTime == null) return string.Empty;

            var notNullaleDateTime = (DateTime)dateTime;
            return notNullaleDateTime.ToFormattedString();
        }
    }
}
