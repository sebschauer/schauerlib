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

/// <summary>
/// Optional data type, simulation of discriminated union
/// <code>option = some of T | none</code>
/// </summary>
public abstract class Option<T>
{
    public abstract bool IsSome { get; }
    public bool IsNone => !IsSome;
}

/// <summary>
/// The option type containing data
/// </summary>
public sealed class Some<T>(T value) : Option<T>
{
    public T Value => value;
    public override bool IsSome => true;
}

public static class Some
{
    /// <summary>
    /// Creating a Some<T> object fluently by using Some.Of("myValue");
    /// </summary>
    /// <returns>The Some<T> object</returns>
    public static Some<T> Of<T>(T value) =>
        new Some<T>(value);
}

/// <summary>
/// The empty option type
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class None<T> : Option<T>
{
    private None() { }
    internal static None<T> Instance { get; } = new None<T>();
    public override bool IsSome => false;
}

public static class None
{
    /// <summary>
    /// Get the None<T> object (there is only one singleton instance per type T)
    /// </summary>
    /// <returns>The None<T> object</returns>
    public static None<T> Of<T>() => 
        None<T>.Instance;
}