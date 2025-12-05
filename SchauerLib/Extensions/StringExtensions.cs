using System.Linq;

namespace SchauerLib.Extensions
{
    public static class StringExtensions
    {
        public static string Without(this string? input, params string?[] delete) =>
            input is null 
            ? null 
            : delete is null
                ? input
                : delete.Aggregate(input, (cur, next) => 
                    string.IsNullOrEmpty(next) 
                        ? cur 
                        : cur.Replace(next, ""));
    }
}
