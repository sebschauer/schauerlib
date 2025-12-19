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

    public class WithoutShould
    {
        private List<int> list = new List<int>{ 1, 2, 3, 4, 5, 4, 3, 2, 1 };

        [Fact]
        public void RemoveEntriesFromCollection()
        {
            var result = list.Without(2, 3);
            Assert.Equivalent(new List<int>{1, 4, 5, 4, 1}, result.ToList());
        }

        [Fact]
        public void IgnoreNonMatchingItems()
        {
            var result = list.Without(2, 6, 7, 8);
            Assert.Equivalent(new List<int>{1, 3, 4, 5, 4, 3, 1}, result.ToList());
        }

        [Fact]
        public void DoNothingOnMissingEntries()
        {
            var result = list.Without();
            Assert.Equivalent(list, result.ToList());
        }

        [Fact]
        public void HandleClassesByReference()
        {
            var (my, other) = (new BaseClass(), new BaseClass());
            var list = new List<BaseClass>{ my, other, my, other, other };
            var result = list.Without(my);
            Assert.Equal(new List<BaseClass>{other, other, other, my}, result.ToList());
        }

        record TestRecord(string Id);

        [Fact]
        public void HandleRecordsByValue()
        {
            var (my, other) = (new TestRecord("sameValue"), new TestRecord("sameValue"));
            var list = new List<TestRecord>{ my, other, my, other, other };
            var result = list.Without(my);
            Assert.Equal(Array.Empty<TestRecord>(), result.ToArray());
        }
    }
}
