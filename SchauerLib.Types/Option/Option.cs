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

public abstract class Option<T>
{
    public abstract bool IsSome { get; }
    public bool IsNone => !IsSome;
}

public sealed class Some<T>(T value) : Option<T>
{
    public T Value => value;
    public override bool IsSome => true;
}

public static class Some
{
    public static Some<T> Of<T>(T value) =>
        new Some<T>(value);
}

public sealed class None<T> : Option<T>
{
    internal static None<T> Instance { get; } = new None<T>();
    public override bool IsSome => false;
}

public static class None
{
    public static None<T> Of<T>() => 
        None<T>.Instance;
}