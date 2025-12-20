# Sebschauer.SchauerLib.Types


## What it is

This nuget contains implementations of some very useful types known from functional programming for C#:

- An `Option<T>: Some<T> | None` type, in some languages also known as `Maybe`, together with a `Bind()` and `Reduce()`.
- An `Result<TSucc, TFail>: Success<TSucc> | Failure<TFail>` type together with some `Bind()` and a `Reduce()` method.


## Resources

Source: https://github.com/sebschauer/schauerlib

Documentation: https://github.com/sebschauer/schauerlib/wiki


## Changelog

### v0.0.1 - 2025/12/18

First version with `Result` and `Option`.


## Copyright & License

Copyright Sebastian Schauer 2025

Published under GPL-3.0-or-later

Questions: schauerlib@sebschauer.de