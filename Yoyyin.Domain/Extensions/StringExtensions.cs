namespace Yoyyin.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Truncates the string to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns>truncated string</returns>
        public static string Truncate(this string input, int length)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = input.LastIndexOf(" ", length);
            return string.Format("{0}...", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }
    }
}
