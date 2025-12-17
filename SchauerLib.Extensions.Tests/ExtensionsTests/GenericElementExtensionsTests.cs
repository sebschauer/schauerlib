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

﻿using SchauerLib.Extensions;

namespace SchauerLib.Tests.ExtensionsTests;

public static class GenericElementExtensionsTests
{
    public class IsOneOfShould
    {
        [Fact]
        public void BeFalseWhenNoMatch()
        {
            Assert.False(5.IsOneOf(1, 2, 3));
            Assert.False("C".IsOneOf("a",  "b", "c"));
            Assert.False(1.6.IsOneOf());
        }

        [Fact]
        public void BeTrueWhenMatch()
        {
            Assert.True(5.IsOneOf(1, 2, 3, 4, 5, 6));
            Assert.True("C".IsOneOf("A", "B", "C", "a", "b", "c"));
        }
    }
}
