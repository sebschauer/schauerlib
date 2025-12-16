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