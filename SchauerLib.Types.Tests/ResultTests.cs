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

using System.Reflection;
using SchauerLib.Types.Result;

namespace SchauerLib.Types.Tests;

public class ResultTests
{
    // Let's imagine this workflow: We retrieve an int from
    // anywhere, divide 6 by this value, if possible, take the value
    // as string, and for some reason we need only the first three
    // letters of the number words, e.g. "one" or "thr".
    //
    // Each step returns a result type.
    //
    // Errors may happen at data retrieval or at processing, e.g. 6 / 0
    // 
    // Each testcase simulates none or one error at a different point in
    // the chain.

    // Here are our stubs.
    private Result<int, Exception> GetNumberOk(int data) => 
        Success.Of(data);
    private Result<int, Exception> GetNumberFail() => 
        Success<int>.GetFailure(new Exception("No data"));
    private Result<string, Exception> DivideSixBy(int data) =>
        data switch
        {
            0 => Success<string>.GetFailure(new Exception("Division by zero")),
            1 => Success.Of("six"), 
            2 => Success.Of("three"), 
            3 => Success.Of("two"),
            6 => Success.Of("one"),
            _ => Success<string>.GetFailure(new Exception("Invalid data"))
        };
    private Result<string, Exception> UseThreeLettersOnly(string data) =>
        Success.Of(data[..3]);
    private string ReduceSuccess(string data) => data + " parts";
    private string ReduceFailure(Exception ex) => ex.Message;

    // To get the result, we chain these function as follows:
    // GetNumberOk(parts) or GetNumbersFail()
    //        .Bind(DivideSixBy)
    //        .Bind(UseThreeLettersOnly)
    //        .Reduce(ReduceSuccess, ReduceFailure);

    [Theory]
    [InlineData(1, "six parts")]
    [InlineData(2, "thr parts")]
    [InlineData(3, "two parts")]
    [InlineData(6, "one parts")]
    public void OkMustWork(int parts, string asserted)
    {
        var result = GetNumberOk(parts)
            .Bind(DivideSixBy)
            .Bind(UseThreeLettersOnly)
            .Reduce(ReduceSuccess, ReduceFailure);

        Assert.Equal(asserted, result);
    }

    [Fact]
    public void NoDataMustWork()
    {
        var result = GetNumberFail()
            .Bind(DivideSixBy)
            .Bind(UseThreeLettersOnly)
            .Reduce(ReduceSuccess, ReduceFailure);

        Assert.Equal("No data", result);
    }

    [Theory]
    [InlineData(0, "Division by zero")]
    [InlineData(4, "Invalid data")]
    [InlineData(5, "Invalid data")]
    [InlineData(1000, "Invalid data")]
    [InlineData(-1, "Invalid data")]
    public void InvalidDataMustWork(int data, string asserted)
    {
        var result = GetNumberOk(data)
            .Bind(DivideSixBy)
            .Bind(UseThreeLettersOnly)
            .Reduce(ReduceSuccess, ReduceFailure);

        Assert.Equal(asserted, result);
    }
}