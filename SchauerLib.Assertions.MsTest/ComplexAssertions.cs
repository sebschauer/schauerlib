using SchauerLib.Assertions.Core;

namespace SchauerLib.Assertions.MsTest
{
	public static class ComplexAssertions
	{
		public static void EitherOr(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
			CombinedAssertionsRunner.RunAssertions(1, 1, firstAssert, secondAssert, moreAsserts);

		public static void NeitherNor(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(0, 0, firstAssert, secondAssert, moreAsserts);

        public static void Or(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, null, firstAssert, secondAssert, moreAsserts);

        public static void PassesExactly(this Assert _, int? minPasses, int? maxPasses, params Action[] asserts) =>
            CombinedAssertionsRunner.RunAssertions(asserts, minPasses, maxPasses);

        public static void If(this Assert assert, Action action) => 
            assert.IfPass(action);

        public static IfThenCollector IfPass(this Assert _, Action ifAction) => 
            new IfThenCollector(ifAction, true);

        public static IfThenCollector IfFail(this Assert _, Action ifAction) => 
            new IfThenCollector(ifAction, false);
    }
}
