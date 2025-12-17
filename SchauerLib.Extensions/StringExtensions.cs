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
