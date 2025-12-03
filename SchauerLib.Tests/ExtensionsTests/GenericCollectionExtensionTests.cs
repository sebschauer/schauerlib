using SchauerLib.Extensions;

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

}
