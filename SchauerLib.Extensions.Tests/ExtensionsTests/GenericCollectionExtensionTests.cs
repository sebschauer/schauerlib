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

public class GenericCollectionExtensionTests
{
    public class FirstOfShould()
    {
        [Fact]
        public void ReturnFirstOccurence()
        {
            var (baseClass, subA1, subA2, subB) = (new BaseClass(), new SubClassA(), new SubClassA(), new SubClassB());
            var list = new List<BaseClass> { baseClass, subA1, subA2, subB };

            Assert.Equal(subA1, list.FirstOf<SubClassA>());
            Assert.Equal(subB, list.FirstOf<SubClassB>());

            var list2 = new List<BaseClass> { subB, baseClass };
            Assert.Equal(subB, list2.FirstOf<BaseClass>());
        }

        [Fact]
        public void ReturnNullWhenNoMatch()
        {
            var (baseClass, subA1, subA2) = (new BaseClass(), new SubClassA(), new SubClassA());
            var list = new List<BaseClass> { baseClass, subA1, subA2 };

            Assert.Null(list.FirstOf<SubClassB>());
        }
    }

    class BaseClass { }
    class SubClassA : BaseClass { }
    class SubClassB : BaseClass { }

}
