# Sebschauer.SchauerLib.Extensions


## What it is

This nuget contains a collection of extension methods I found useful over time:

- `T? FirstOf<T>(this IEnumerable list)`: Returns the first element of the specified type in the list, casted to `T`
- `bool IsOneOf(this T el, params T[] candidates)`: Returns whether `el` is one of the candidates. Makes code more readable: 
  - Before: `if (new[] { 'w', 'a', 's', 'd' }.Contains(myChar)) { ... }`
  - After: `if (myChar.IsOneOf('w', 'a', 's', 'd')) { ... }`
- `string? Without(this string? haystack, params string?[] needles)`: Removes the needles from haystack, preserving null values.
  - Before: `var cleaned = rawString.Replace(".", "").Replace(",", "").Replace(" ", "");`
  - After: `var cleaned = rawString.Without(".", ",", " ");`


## Resources

Source: https://github.com/sebschauer/schauerlib

Documentation: https://github.com/sebschauer/schauerlib/wiki


## Changelog

### v0.0.1 - 2025/12/18

First version with `FirstOf`, `IsOneOf` and `Without`.


## Copyright & License

Copyright Sebastian Schauer 2025

Published under GPL-3.0-or-later

Questions: schauerlib@sebschauer.de