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

namespace SchauerLib.Types.Option;

public static class OptionBehaviour
{
    /// <summary>
    /// Get a value wrapped by an Option object
    /// </summary>
    public static Some<T> ToOptionSome<T>(this T value) =>
        Some.Of(value);

    /// <summary>
    /// Get the None object of the type T
    /// </summary>
    public static None<T> ToOptionNone<T>(this T value) =>
        None.Of<T>();

    /// <summary>
    /// Returns the result of <paramref name="function"/> in case 
    /// <paramref name="option"/> is of type Some<TIn>. If it's 
    /// of type None<TIn>, None<TOut> is returned. 
    /// </summary>
    /// <typeparam name="TIn">Input option type</typeparam>
    /// <typeparam name="TOut">Output option type</typeparam>
    /// <param name="option">Input option</param>
    /// <param name="function">Function the value of option is applied to</param>
    /// <returns>The resulting Option<TOut> object</returns>
    /// <exception cref="InvalidOperationException">In case option is neither Some nor None</exception>
    public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, 
        Func<TIn, Option<TOut>> function) =>
        option switch
        {
            Some<TIn> some => function(some.Value),
            None<TIn> _ => None.Of<TOut>(),
            _ => throw new InvalidOperationException("unknown option type")
        };

    /// <summary>
    /// Returns the result of <paramref name="function"/> in case 
    /// <paramref name="option"/> is of type Some<TIn>. If it's 
    /// of type None<TIn>, None<TOut> is returned. 
    /// </summary>
    /// <typeparam name="TIn">Input option type</typeparam>
    /// <typeparam name="TState">Function parameter type</typeparam>
    /// <typeparam name="TOut">Output option type</typeparam>
    /// <param name="option">Input option</param>
    /// <param name="function">Function the value of option is applied to</param>
    /// <param name="state">Function parameter</param>
    /// <returns>The resulting Option<TOut> object</returns>
    /// <exception cref="InvalidOperationException">In case option is neither Some nor None</exception>
    public static Option<TOut> Bind<TIn, TState, TOut>(this Option<TIn> option, 
        Func<TIn, TState, Option<TOut>> function, TState state) =>
        option switch
        {
            Some<TIn> some => function(some.Value, state),
            None<TIn> _ => None.Of<TOut>(),
            _ => throw new InvalidOperationException("unknown option type")
        };

    public static TOut Reduce<TIn, TOut>(this Option<TIn> option,
        Func<TIn, TOut> someReducer, TOut noneValue) =>
        option switch
        {
            Some<TIn> some => someReducer(some.Value),
            None<TIn> _ => noneValue,
            _ => throw new InvalidOperationException("unknown option type")
        };
}