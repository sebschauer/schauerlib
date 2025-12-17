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

namespace SchauerLib.Types.Result;

public static class ResultExtensions
{
    // Dynamic failure type

    /// <summary>
    /// Transforms <paramref name="result"/> via the passed function
    /// in case of success, passes Failure otherwise
    /// </summary>
    /// <typeparam name="TSuccIn"></typeparam>
    /// <typeparam name="TSuccOut"></typeparam>
    /// <typeparam name="TFail"></typeparam>
    /// <param name="result"></param>
    /// <param name="succesTransformer">Function transforming the success data to a new result</param>
    /// <returns>The new result</returns>
    /// <exception cref="InvalidOperationException">In case of result being neither success nor failure. For compiler only.</exception>
    public static Result<TSuccOut, TFailOut> Bind<TSuccIn, TSuccOut, TFail>(
        this Result<TSuccIn, TFail> result, 
        Func<TSuccIn, Result<TSuccOut, TFail>> succesTransformer) =>
        result switch
        {
            Success<TSuccIn, TFail> success => succesTransformer(success.Value),
            Failure<TSuccIn, TFail> failure => Failure.Of<TSuccOut>(failure.FailData),
            _ => throw new InvalidOperationException("unknown result type")
        };

    /// <summary>
    /// Invokes one of two functions depending on <paramref name="result"/>, 
    /// transforming either the success object or the failure object
    /// </summary>
    /// <typeparam name="TSuccIn"></typeparam>
    /// <typeparam name="TFailIn"></typeparam>
    /// <typeparam name="TSuccOut"></typeparam>
    /// <typeparam name="TFailOut"></typeparam>
    /// <param name="result"></param>
    /// <param name="succesTransformer">Function transforming the success data to a new result</param>
    /// <param name="failureTransformer">Function transforming the failure data to a new result</param>
    /// <returns>The new result</returns>
    /// <exception cref="InvalidOperationException">In case of result being neither success nor failure. For compiler only.</exception>
    public static Result<TSuccOut, TFailOut> Bind<TSuccIn, TFailIn, TSuccOut, TFailOut>(
        this Result<TSuccIn, TFailIn> result, 
        Func<TSuccIn, Result<TSuccOut, TFailOut>> succesTransformer,
        Func<TFailIn, Result<TSuccOut, TFailOut>> failureTransformer) =>
        result switch
        {
            Success<TSuccIn, TFailIn> success => succesTransformer(success.Value),
            Failure<TSuccIn, TFailIn> failure => failureTransformer(failure.FailData),
            _ => throw new InvalidOperationException("unknown result type")
        };


    // Fixed failure type: Exception

    /// <summary>
    /// Transforms the success object via the function parameter,
    /// or hands over the failure (an Exception).
    /// </summary>
    /// <typeparam name="TSuccIn"></typeparam>
    /// <typeparam name="TSuccOut"></typeparam>
    /// <param name="result"></param>
    /// <param name="successTransformer">Function transforming the success to a new result</param>
    /// <returns>The new result</returns>
    /// <exception cref="InvalidOperationException">In case of result being neither success nor failure. For compiler only.</exception>
    public static Result<TSuccOut, Exception> Bind<TSuccIn, TSuccOut>(
        this Result<TSuccIn, Exception> result,
        Func<TSuccIn, Result<TSuccOut, Exception>> successTransformer) => 
        result switch
        {
            Success<TSuccIn> success => successTransformer(success.Value),
            Failure<TSuccIn> failure => Failure.Of<TSuccOut>(failure.FailData),
            _ => throw new InvalidOperationException("unknown result type")
        };
}