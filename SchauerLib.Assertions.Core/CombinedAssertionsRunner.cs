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

﻿namespace SchauerLib.Assertions.Core;

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
