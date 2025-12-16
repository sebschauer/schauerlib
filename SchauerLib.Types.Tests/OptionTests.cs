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

using System.Reflection;
using SchauerLib.Types.Option;

namespace SchauerLib.Types.Tests;

public class OptionTests
{
    [Fact]
    public void UsageDemo()
    {
        Option<int> DivideFourBy(int number) =>
            number switch
            {
                0 => None.Of<int>(),
                _ => Some.Of(4 / number)
            };
            
        Option<string> ToStringResult(int number) =>
            number switch
            {
                4 => Some.Of("four"),
                2 => Some.Of("two"),
                1 => Some.Of("one"),
                0 => None.Of<string>(),
                _ => throw new Exception("cannot happen in this test")
            };
        
        var resultOne = DivideFourBy(4)
            .Bind(ToStringResult);
        Assert.IsType<Some<string>>(resultOne);
        Assert.Equal("one", ((Some<string>)resultOne).Value);
        Assert.True(resultOne.IsSome);

        var resultTooMuch = DivideFourBy(1000)
            .Bind(ToStringResult);
        Assert.IsType<None<string>>(resultTooMuch);
        Assert.True(resultTooMuch.IsNone);

        var resultImpossible = DivideFourBy(0)
            .Bind(ToStringResult);
        Assert.IsType<None<string>>(resultImpossible);
        Assert.False(resultImpossible.IsSome);
    }
}