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

namespace SchauerLib.Assertions.Xunit.Tests;

public class ComplexAssertionsTests
{
    private readonly Action _pass = () => Assert.True(true);
    private readonly Action _fail = () => Assert.True(false);

    [Fact]
    public void EitherOrMustWork()
    {
        Assert.EitherOr(_fail, _fail, _pass, _fail);
        Fail(() => Assert.EitherOr(_fail, _fail, _fail));
        Fail(() => Assert.EitherOr(_fail, _pass, _pass, _fail));
        Fail(() => Assert.EitherOr(_pass, _pass, _pass, _pass));
    }

    [Fact]
    public void OrMustWork()
    {
        Assert.Or(_fail, _fail, _pass, _fail);
        Assert.Or(_pass, _pass, _pass, _pass);
        Fail(() => Assert.Or(_fail, _fail, _fail, _fail));
    }

    [Fact]
    public void NeitherNorMustWork()
    {
        Assert.NeitherNor(_fail, _fail, _fail, _fail);
        Fail(() => Assert.NeitherNor(_fail, _fail, _fail, _pass));
        Fail(() => Assert.NeitherNor(_pass, _pass, _pass, _pass));
    }

    [Fact]
    public void IfPassesMustWork()
    {
        string path = "";
        Assert.IfPass(_fail)
            .Then(() => path = "then")
            .Else(() => path = "else");
        Assert.Equal("else", path);

        path = "";
        Assert.IfPass(_pass)
            .Then(() => path = "then")
            .Else(() => path = "else");
        Assert.Equal("then", path);
    }

    [Fact]
    public void IfFailMustWork()
    {
        string path = "";
        Assert.IfFail(_pass)
            .Then(() => path = "then")
            .Else(() => path = "else");
        Assert.Equal("else", path);

        path = "";
        Assert.IfFail(_fail)
            .Then(() => path = "then")
            .Else(() => path = "else");
        Assert.Equal("then", path);
    }

    private void Fail(Action action)
    {
        try
        {
            action();
            throw new Exception("Action should have failed, but did not");
        }
        catch
        {
            return;
        }
    }
}
