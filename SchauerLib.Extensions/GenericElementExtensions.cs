using System.Linq;

namespace SchauerLib.Extensions
{
    /// <summary>
    /// Extension methods for single generic objects
    /// </summary>
    public static class GenericElementExtensions
    {
        /// <summary>
        /// Returns true, if <c>element</c> is one of the candidates
        /// </summary>
        /// <example>
        /// Example:
        /// <code>
        /// var input = Console.ReadLine();
        /// foreach(var c in input)
        /// {
        ///     if (c.IsOneOf('-', ' ', '.', 'w', 'a', 's', 'd')
        ///     {
        ///         //...
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the element and candidates</typeparam>
        /// <param name="element">The element to compare</param>
        /// <param name="candidates">The candidates to search for equality</param>
        /// <returns>True if <c>element</c> is found in <c>candidates</c>, otherwise <c>null</c>.</returns>
        public static bool IsOneOf<T>(this T element, params  T[] candidates) =>
            candidates.Contains(element);
    }
}
