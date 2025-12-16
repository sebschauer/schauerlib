using SchauerLib.Assertions.Core;

namespace SchauerLib.Assertions.MsTest
{
	public static class ComplexAssertions
	{
        /// <summary>
        /// Passes if exact one of the assertions passes and the others are failing
        /// </summary>
        public static void Xor(this Assert assert, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            assert.EitherOr(firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if exact one of the assertions passes and the others are failing
        /// </summary>
		public static void EitherOr(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
			CombinedAssertionsRunner.RunAssertions(1, 1, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if all assertions are failing
        /// </summary>
        public static void NeitherNor(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(0, 0, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if at least one of the assertions passes
        /// </summary>
        public static void Or(this Assert _, Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, null, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if minPasses <= number of passing assertions <= maxPasses. If minPasses or maxPasses is null, 
        /// the comparison is not executed.
        /// </summary>
        public static void PassesExactly(this Assert _, int? minPasses, int? maxPasses, params Action[] asserts) =>
            CombinedAssertionsRunner.RunAssertions(asserts, minPasses, maxPasses);

        /// <summary>
        /// Alias for <see cref="IfPass"/>
        /// </summary>
        public static void If(this Assert assert, Action action) => 
            assert.IfPass(action);

        /// <summary>
        /// Conditional testing: IfPass(assert1).Then(assert2) tests assert2 only if assert1 passes.
        /// </summary>
        public static IfThenCollector IfPass(this Assert _, Action ifAction) => 
            new IfThenCollector(ifAction, true);

        /// <summary>
        /// Conditional testing: IfFail(assert1).Then(assert2) tests assert2 only if assert1 fails.
        /// </summary>
        public static IfThenCollector IfFail(this Assert _, Action ifAction) => 
            new IfThenCollector(ifAction, false);
    }
}
