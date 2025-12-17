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

﻿using System.Linq;

namespace SchauerLib.Extensions;

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
