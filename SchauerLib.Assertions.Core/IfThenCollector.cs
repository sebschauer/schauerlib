namespace SchauerLib.Assertions.Core;

public class IfThenCollector(Action ifAction, bool checkThenOnPass)
{
    public void Then(Action thenAction)
    {
        if (CombinedAssertionsRunner.RunAction(ifAction).Success == checkThenOnPass)
        {
            thenAction();
        }
    }
}