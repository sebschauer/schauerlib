/* Copyright Sebastian Schauer, 2025
 *
 * This file is part of SchauerLib.
 *
 * SchauerLib is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SchauerLib is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SchauerLib.  If not, see <http://www.gnu.org/licenses/>.
 */

using SchauerLib.Assertions.Core;

namespace Xunit
{
    /// <summary>
    /// Extensions for Xunit asserts
    /// </summary>
    public partial class Assert
    {
        /// <summary>
        /// Passes if exact one of the assertions passes and the others are failing
        /// </summary>
        public static void Xor(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            EitherOr(firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if exact one of the assertions passes and the others are failing
        /// </summary>
        public static void EitherOr(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, 1, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if all assertions are failing
        /// </summary>
        public static void NeitherNor(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(0, 0, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if at least one of the assertions passes
        /// </summary>
        public static void Or(Action firstAssert, Action secondAssert, params Action[] moreAsserts) =>
            CombinedAssertionsRunner.RunAssertions(1, null, firstAssert, secondAssert, moreAsserts);

        /// <summary>
        /// Passes if minPasses <= number of passing assertions <= maxPasses. If minPasses or maxPasses is null, 
        /// the comparison is not executed.
        /// </summary>
        public static void PassesExactly(int? minPasses, int? maxPasses, params Action[] asserts) =>
            CombinedAssertionsRunner.RunAssertions(asserts, minPasses, maxPasses);

        /// <summary>
        /// Alias for <see cref="IfPass"/>
        /// </summary>
        public static void If(Action action) => 
            IfPass(action);

        /// <summary>
        /// Conditional testing: IfPass(assert1).Then(assert2) tests assert2 only if assert1 passes.
        /// </summary>
        public static IfThenCollector IfPass(Action ifAction) => 
            new IfThenCollector(ifAction, true);

        /// <summary>
        /// Conditional testing: IfFail(assert1).Then(assert2) tests assert2 only if assert1 fails.
        /// </summary>
        public static IfThenCollector IfFail(Action ifAction) => 
            new IfThenCollector(ifAction, false);
    }
}
