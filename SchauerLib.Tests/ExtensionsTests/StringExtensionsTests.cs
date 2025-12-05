using SchauerLib.Extensions;

namespace SchauerLib.Tests.ExtensionsTests;

public static class StringExtensionsTests
{
    public class WithoutShould
    {
        [Fact]
        public void ChangeNothingOnNoMatch()
        {
            var original = "123 abc DEF §$%";

            Assert.Equal(original, original.Without());
            Assert.Equal(original, original.Without("xyz"));
            Assert.Equal(original, original.Without(""));
            Assert.Equal(original, original.Without(null!));
        }

        [Fact]
        public void Work()
        {
            var original = "123 abc DEF";

            Assert.Equal("123abcDEF",   original.Without(" "));
            Assert.Equal("123 DEF",     original.Without("abc "));
            Assert.Equal("13 abc DEF",  original.Without("2"));
            Assert.Equal("13 abc E",    original.Without("2", "D", "F"));
            Assert.Equal("13 a DEF",    original.Without("2", "DF", "b", "c"));
        }

        [Fact]
        public void HandleNullCorrectly() 
        {
            string? haystackFilled = "To be or not to be";
            string? needleFilled = " be";
            string? haystackEmpty = null;
            string? needleEmpty = null;

            Assert.Null(haystackEmpty.Without(needleFilled));
            Assert.Null(haystackEmpty.Without(needleEmpty!));

            Assert.Equal(haystackFilled, haystackFilled.Without());
            Assert.Equal(haystackFilled, haystackFilled.Without(needleEmpty));
            Assert.Equal("To or not to", haystackFilled.Without(needleFilled));
        }
    }
}
