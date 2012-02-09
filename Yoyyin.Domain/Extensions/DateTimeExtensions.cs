using System;
using System.Globalization;

namespace Yoyyin.Domain.Extensions
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
            int days = DateTime.Now.DayOfYear - dateTime.DayOfYear;

            switch (days)
            {
                case 0:
                    return "Idag klockan " + dateTime.ToString("HH:mm");
                case 1:
                    return "Igår klockan " + dateTime.ToString("HH:mm");
                default:
                    var cultureInfo = new CultureInfo("sv-SE");
                    return dateTime.ToString("dddd dd MMMM yyyy HH:mm", cultureInfo);
            }
        }

        public static string ToFormattedString(this DateTime? dateTime)
        {
            if (dateTime == null) return string.Empty;

            var notNullaleDateTime = (DateTime)dateTime;
            return notNullaleDateTime.ToFormattedString();
        }
    }
}
