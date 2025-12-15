using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SchauerLib.Assertions.MsTest
{
	public static class CombinedAssertions
	{
		public static void EitherOr(this Assert assert, Action firstAssert, Action secondAssert, params Action[] moreAsserts)
		{
			var all = new List<Action>{ firstAssert, secondAssert };
			all.AddRange(moreAsserts);
			var matches = 0;
			foreach (var action in all)
			{
				if (RunAction(action).Item1)
				{
					matches++;
				}

				if (matches > 1)
				{
					throw new Exception("Exact one assertion expected to match, but was more");
				}
			}
			if (matches == 0)
			{
				throw new Exception("Exact one assertion expected to match, but was none");
			}
		}

		private static (bool, Exception?) RunAction(Action action)
		{
			try
			{
				action();
				return (true, null);
			}
			catch(Exception ex)
			{
				return (false, ex);
			}
		}
	}
}
