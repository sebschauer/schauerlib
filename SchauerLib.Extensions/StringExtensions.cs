using System.Linq;

namespace SchauerLib.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Deletes all occurences of all <c>needles</c> entries in <c>haystack</c>. 
        /// Ignores <c>null</c> and empty values.
        /// </summary>
        /// <param name="haystack">The Haystack</param>
        /// <param name="needles">The needles</param>
        /// <returns>The haystack without all needles</returns>
        public static string? Without(this string? haystack, params string?[] needles) =>
            haystack is null 
            ? null 
            : needles is null
                ? haystack
                : needles.Aggregate(haystack, (cur, next) => 
                    string.IsNullOrEmpty(next) 
                        ? cur 
                        : cur.Replace(next, ""));
    }
}
