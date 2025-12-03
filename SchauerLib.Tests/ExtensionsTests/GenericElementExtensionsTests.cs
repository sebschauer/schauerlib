using SchauerLib.Extensions;

namespace SchauerLib.Tests.ExtensionsTests;

public static class GenericElementExtensionsTests
{
    public class IsOneOfShould
    {
        [Fact]
        public void BeFalseWhenNoMatch()
        {
            Assert.False(5.IsOneOf(1, 2, 3));
            Assert.False("C".IsOneOf("a",  "b", "c"));
            Assert.False(1.6.IsOneOf());
        }

        [Fact]
        public void BeTrueWhenMatch()
        {
            Assert.True(5.IsOneOf(1, 2, 3, 4, 5, 6));
            Assert.True("C".IsOneOf("A", "B", "C", "a", "b", "c"));
        }
    }
}
