/* Copyright Sebastian Schauer, 2025
 *
 * This file is part of SchauerLib.
 *
 *  SchauerLib is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  SchauerLib is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
 */

﻿using SchauerLib.Extensions;

namespace SchauerLib.Tests.ExtensionsTests;

public static class StringExtensionsTests
{
    public class WithoutShould
    {
        [Fact]
        public void ChangeNothingOnNoMatch()
        {
            var original = "123 abc DEF §$%";

            Assert.Equal(original, original.Without());
            Assert.Equal(original, original.Without("xyz"));
            Assert.Equal(original, original.Without(""));
            Assert.Equal(original, original.Without(null!));
        }

        [Fact]
        public void Work()
        {
            var original = "123 abc DEF";

            Assert.Equal("123abcDEF",   original.Without(" "));
            Assert.Equal("123 DEF",     original.Without("abc "));
            Assert.Equal("13 abc DEF",  original.Without("2"));
            Assert.Equal("13 abc E",    original.Without("2", "D", "F"));
            Assert.Equal("13 a DEF",    original.Without("2", "DF", "b", "c"));
        }

        [Fact]
        public void HandleNullCorrectly() 
        {
            string? haystackFilled = "To be or not to be";
            string? needleFilled = " be";
            string? haystackEmpty = null;
            string? needleEmpty = null;

            Assert.Null(haystackEmpty.Without(needleFilled));
            Assert.Null(haystackEmpty.Without(needleEmpty!));

            Assert.Equal(haystackFilled, haystackFilled.Without());
            Assert.Equal(haystackFilled, haystackFilled.Without(needleEmpty));
            Assert.Equal("To or not to", haystackFilled.Without(needleFilled));
        }
    }
}
