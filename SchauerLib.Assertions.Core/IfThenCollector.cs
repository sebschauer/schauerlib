/* Copyright Sebastian Schauer, 2025
 *
 * This file is part of SchauerLib.
 *
 *  SchauerLib is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  SchauerLib is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
 */

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
