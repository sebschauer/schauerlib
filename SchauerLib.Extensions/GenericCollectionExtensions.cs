using System.Collections;

namespace SchauerLib.Extensions
{
    /// <summary>
    /// Extension methods for IEnumerable, IList, ICollection, ...
    /// </summary>
    public static class GenericCollectionExtensions
    {
        /// <summary>
        /// Returns the first element of the specified type <c>TElement</c> in <c>collection</c>, 
        /// casted to <c>TElement</c>, if it exists; otherwise <c>null</c>.
        /// </summary>
        /// <example>
        /// <code>
        /// var (car, bike, ship) = (new Car(), new Bicycle(), new Ship());
        /// var list = [ car, ship, car, bike, ship, bike ];
        /// list.FirstOf<Bicycle>()
        ///     .DriveForestPath();
        /// </code>
        /// </example>
        /// <typeparam name="TElement">The searched type</typeparam>
        /// <param name="collection">The list to search for</param>
        /// <returns>The first match or null</returns>
        public static TElement? FirstOf<TElement>(this IEnumerable collection)
            where TElement : class 
        {
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is TElement element)
                {
                    return element;
                }
            }

            return null;
        }
    }
}
