namespace SchauerLib.Assertions.Core;

public static class CombinedAssertionsRunner
{
    public static void RunAssertions(int? min, int? max, Action firstAssert, Action secondAssert, params Action[] moreAsserts)
    {
        var actions = new List<Action>{ firstAssert, secondAssert };
        actions.AddRange(moreAsserts);
        RunAssertions(actions, min, max);
    }

    public static void RunAssertions(IEnumerable<Action> actions, int? minMatches, int? maxMatches)
    {
        var matches = 0;
        foreach (var action in actions)
        {
            if (RunAction(action).Success)
            {
                matches++;
            }

            if (maxMatches.HasValue && matches > maxMatches.Value)
            {
                throw new Exception($"Expected {(minMatches == maxMatches ? "exact " : "max. ")} {maxMatches}, but was {matches}");
            }
        }
        if (minMatches.HasValue && matches < minMatches.Value)
        {
            throw new Exception($"Expected {(minMatches == maxMatches ? "exact " : "min. ")} {minMatches}, but was {matches}");
        }
    }

    public static (bool Success, Exception? exception) RunAction(Action action)
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
