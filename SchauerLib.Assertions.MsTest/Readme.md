# Sebschauer.SchauerLib.Assertions.MsTest


## What it is

This nuget contains some MSTest Assert extensions for handling multiple assertions which depend on each other's assertion result:

- `EitherOr(assertions)` and its alias `Xor(assertions)`: Passes if exact one of the passed assertions passes and all others are failing.
- `NeitherNor(assertion)`: Passes if all passed assertions are failing.
- `Or(assertions)`: Passes if at least one of the passed assertions passes.
- `PassesExactly(min, max, assertions)`: Passes if the number of passing assertions lies in the inclusive range `min <= passings <= max`. Ignores Checking a range boundary if it is null.
- `IfPass(assertion1).Then(assertion2)`, its alias `If` and the opposite function `IfFail` check `assertion2` only if `assertion1` passed (or failed in the latter case).

## Example

```
Assert.That.EitherOr(
  () => Assert.Equal(2, primeNumber),
  () => Assert.Equal(1, primeNumber % 2)
);

Assert.That
  .IfFail(() => Assert.Equal(0, x))
  .Then(  () => Assert.NotEqual(0, 1 / x));
```


## Resources

Source: https://github.com/sebschauer/schauerlib

Documentation: https://github.com/sebschauer/schauerlib/wiki


## Changelog

### v0.0.1 - 2025/12/18

First version with `EitherOr`, `Or`, `NeitherNor`, `PassesExactly`, `If/IfPass().Then` and `IfFail().Then`


## Copyright & License

Copyright Sebastian Schauer 2025

Published under GPL-3.0-or-later

Questions: schauerlib@sebschauer.de