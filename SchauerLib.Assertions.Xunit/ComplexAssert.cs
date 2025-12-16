using SchauerLib.Assertions.Core;

namespace Xunit
{
    public partial class Assert
    {
        public static void EitherOr(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, 1, firstAssert, secondAssert, moreAsserts);

        public static void NeitherNor(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(0, 0, firstAssert, secondAssert, moreAsserts);

        public static void Or(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, null, firstAssert, secondAssert, moreAsserts);

        public static void PassesExactly(int? minPasses, int? maxPasses, params Action[] asserts) =>
            CombinedAssertionsRunner.RunAssertions(asserts, minPasses, maxPasses);

        public static void If(Action action) => 
            IfPass(action);

        public static IfThenCollector IfPass(Action ifAction) => 
            new IfThenCollector(ifAction, true);

        public static IfThenCollector IfFail(Action ifAction) => 
            new IfThenCollector(ifAction, false);
    }
}