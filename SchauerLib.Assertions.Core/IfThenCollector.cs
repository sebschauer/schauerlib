namespace SchauerLib.Assertions.Core;

/// <summary>
/// The class handling the conditional if-then assertion
/// </summary>
/// <param name="ifAction">The action to perform to see if the condition is fulfilled</param>
/// <param name="checkThenOnPass">Whether the ifAction shall pass (true) or fail (false) to check the thenAction</param>
public class IfThenCollector(Action ifAction, bool checkThenOnPass)
{
    /// <summary>
    /// Triggers the conditional test, takes the assertion to assert maybe
    /// </summary>
    /// <param name="thenAction"></param>
    public void Then(Action thenAction)
    {
        if (CombinedAssertionsRunner.RunAction(ifAction).Success == checkThenOnPass)
        {
            thenAction();
        }
    }
}