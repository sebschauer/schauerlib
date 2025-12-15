using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchauerLib.Assertions.Core;

namespace SchauerLib.Assertions.MsTest
{
	public static class CombinedAssertions
	{
		public static void EitherOr(this Assert assert, Action firstAssert, Action secondAssert, params Action[] moreAsserts)
		{
			var actions = new List<Action>{ firstAssert, secondAssert };
			actions.AddRange(moreAsserts);
			CombinedAssertionsRunner.RunAssertions(actions, 1, 1);
		}
	}
}
