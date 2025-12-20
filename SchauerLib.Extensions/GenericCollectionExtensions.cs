/* Copyright Sebastian Schauer, 2025
 *
 * This file is part of SchauerLib.
 *
 * SchauerLib is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SchauerLib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SchauerLib.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SchauerLib.Extensions;

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

    /// <summary>
    /// Removes the given elements from the list
    /// </summary>
    /// <typeparam name="T">type of elements and list</typeparam>
    /// <param name="collection">the collection to be removed from</param>
    /// <param name="removeItems">the item to be removed</param>
    /// <returns>list without removeItems</returns>
    public static IEnumerable<T> Without<T>(this IEnumerable<T> collection, params T[] removeItems) =>
        collection.Where(item => !removeItems?.Contains(item) ?? true);
}
