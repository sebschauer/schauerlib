namespace SchauerLib.Assertions.MsTest.Tests;

[TestClass]
public class CombinedAssertionsTests
{
    [TestMethod]
    public void EitherOrMustWork()
    {
    	Assert.That.EitherOr(
    		() => Assert.IsTrue(false),
    		() => Assert.IsTrue(false),
    		() => Assert.IsTrue(true),
    		() => Assert.IsTrue(false)
    	);
    }
}