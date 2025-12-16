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
        Assert.IfPass(_fail).Then(() => throw new Exception("not thrown"));
        Fail(() => Assert.IfPass(_pass).Then(() => throw new Exception("thrown")));
    }

    [Fact]
    public void IfFailMustWork()
    {
        Assert.IfFail(_pass).Then(() => throw new Exception("not thrown"));
        Fail(() => Assert.IfFail(_fail).Then(() => throw new Exception("thrown")));
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