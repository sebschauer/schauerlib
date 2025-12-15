using SchauerLib.Assertions.Core;

namespace Xunit
{
    public partial class Assert
    {
        public static void EitherOr(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            Run(1, 1, firstAssert, secondAssert, moreAsserts);

        public static void NeitherNor(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            Run(0, 0, firstAssert, secondAssert, moreAsserts);

        public static void Or(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            Run(1, null, firstAssert, secondAssert, moreAsserts);

        public static void PassesExactly(int? minPasses, int? maxPasses, params Action[] asserts) =>
            CombinedAssertionsRunner.RunAssertions(asserts, minPasses, maxPasses);

        public static IfThenCollector IfPasses(Action ifAction) => 
            new IfThenCollector(ifAction);

        private static void Run(int? min, int? max, Action firstAssert, Action secondAssert, params Action[] moreAsserts)
        {
            var actions = new List<Action>{ firstAssert, secondAssert };
			actions.AddRange(moreAsserts);
			CombinedAssertionsRunner.RunAssertions(actions, min, max);
        }
    }
}