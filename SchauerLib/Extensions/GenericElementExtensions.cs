using System.Linq;

namespace SchauerLib.Extensions
{
    public static class GenericElementExtensions
    {
        public static bool IsOneOf<T>(this T element, params  T[] candidates) =>
            candidates.Contains(element);

    }
}
