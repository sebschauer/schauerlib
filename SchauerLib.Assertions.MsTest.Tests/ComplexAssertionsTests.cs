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

namespace SchauerLib.Assertions.MsTest.Tests;

[TestClass]
public class ComplexAssertionsTests
{
	private readonly Action _pass = () => Assert.IsTrue(true);
    private readonly Action _fail = () => Assert.IsTrue(false);

    [TestMethod]
    public void EitherOrMustWork()
    {
    	Assert.That.EitherOr(_fail, _fail, _pass, _fail);
        Fail(() => Assert.That.EitherOr(_fail, _fail, _fail));
        Fail(() => Assert.That.EitherOr(_fail, _pass, _pass, _fail));
        Fail(() => Assert.That.EitherOr(_pass, _pass, _pass, _pass));
    }

	[TestMethod]
    public void OrMustWork()
    {
        Assert.That.Or(_fail, _fail, _pass, _fail);
        Assert.That.Or(_pass, _pass, _pass, _pass);
        Fail(() => Assert.That.Or(_fail, _fail, _fail, _fail));
    }

    [TestMethod]
    public void NeitherNorMustWork()
    {
        Assert.That.NeitherNor(_fail, _fail, _fail, _fail);
        Fail(() => Assert.That.NeitherNor(_fail, _fail, _fail, _pass));
        Fail(() => Assert.That.NeitherNor(_pass, _pass, _pass, _pass));
    }

    [TestMethod]
    public void IfPassesMustWork()
    {
        Assert.That.IfPass(_fail).Then(() => throw new Exception("not thrown"));
        Fail(() => Assert.That.IfPass(_pass).Then(() => throw new Exception("thrown")));
    }

    [TestMethod]
    public void IfFailMustWork()
    {
        Assert.That.IfFail(_pass).Then(() => throw new Exception("not thrown"));
        Fail(() => Assert.That.IfFail(_fail).Then(() => throw new Exception("thrown")));
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
