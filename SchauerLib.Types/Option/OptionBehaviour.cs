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
    public static Some<T> ToOptionSome<T>(this T value) =>
        Some.Of(value);

    public static None<T> ToOptionNone<T>(this T value) =>
        None.Of<T>();

    public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, 
        Func<TIn, Option<TOut>> function) =>
        option switch
        {
            Some<TIn> some => function(some.Value),
            None<TIn> _ => None.Of<TOut>(),
            _ => throw new InvalidOperationException("unknown option type")
        };

    public static Option<TOut> Bind<TIn, TState, TOut>(this Option<TIn> option, 
        Func<TIn, TState, Option<TOut>> function, TState state) =>
        option switch
        {
            Some<TIn> some => function(some.Value, state),
            None<TIn> _ => None.Of<TOut>(),
            _ => throw new InvalidOperationException("unknown option type")
        };
}