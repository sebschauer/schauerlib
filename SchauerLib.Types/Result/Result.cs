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

/// <summary>
/// Two-type data type, simulation of discriminated union
/// <code>result = success of TSucc | failure of TFail</code>
/// </summary>
/// <typeparam name="TSucc">Type of success</typeparam>
/// <typeparam name="TFail">Type of failure</typeparam>
public abstract class Result<TSucc, TFail>
{
    public abstract object? Content { get; }
    public abstract bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
}

/// <summary>
/// The success result object with generic failure type.
/// </summary>
/// <typeparam name="TSucc">The success type</typeparam>
/// <typeparam name="TFail">The failure type</typeparam>
/// <param name="value">The success data</param>
public class Success<TSucc, TFail>(TSucc value) : Result<TSucc, TFail>
{
    public TSucc Value => value;
    public override object? Content => value;
    public override bool IsSuccess => true;
}

/// <summary>
/// The success result object with fixed failure type Exception
/// </summary>
/// <typeparam name="TSucc">The success type</typeparam>
/// <param name="value">The success data</param>
public class Success<TSucc>(TSucc value) : Success<TSucc, Exception>(value)
{
    /// <summary>
    /// Creates a failure object with the given data. Useful for fluent notation,
    /// collects the types more readable
    /// </summary>
    /// <typeparam name="TSucc"></typeparam>
    /// <typeparam name="TFail"></typeparam>
    /// <param name="failData"></param>
    /// <returns></returns>
    public static Failure<TSucc, TFail> GetFailure<TFail>(TFail failData) =>
        new Failure<TSucc, TFail>(failData);
}

public static class Success
{
    /// <summary>
    /// Creates a success result object with Exception as failure type.
    /// </summary>
    /// <typeparam name="TSucc"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Success<TSucc> Of<TSucc>(TSucc value) =>
        new Success<TSucc>(value);
}

/// <summary>
/// The failure result object with generic failure type
/// </summary>
/// <typeparam name="TSucc">The success type</typeparam>
/// <typeparam name="TFail">The failure type</typeparam>
/// <param name="failure">The failure data</param>
public class Failure<TSucc, TFail>(TFail failure) : Result<TSucc, TFail>
{
    public TFail FailData => failure;
    public override object? Content => failure;
    public override bool IsSuccess => false;
}

/// <summary>
/// The failure result object with fixed failure type Exception
/// </summary>
/// <typeparam name="TSucc"></typeparam>
/// <param name="exception"></param>
public class Failure<TSucc>(Exception exception) : Failure<TSucc, Exception>(exception)
{
}

public static class Failure
{
    /// <summary>
    /// Creates a failure object with failure type Exception
    /// </summary>
    /// <typeparam name="TSucc"></typeparam>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static Failure<TSucc> Of<TSucc>(Exception exception) =>
        new Failure<TSucc>(exception);
}