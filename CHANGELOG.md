# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.8]

### Added
- `PackageIcon` metadata referencing `package-icon.png` for the NuGet package.
- Symbol package generation (`.snupkg`) via `IncludeSymbols` and `SymbolPackageFormat`.
- `TreatWarningsAsErrors` enabled for the library project to enforce stricter build quality.
- `[DoesNotReturn]` attribute on internal throwing helper methods in `ArgumentOutOfRangeExceptionExtensions` and `IndexOutOfRangeExceptionExtensions` to improve nullable-flow analysis for callers.

### Changed
- `IndexOutOfRangeException.ThrowIf<T>` now accepts `IReadOnlyCollection<T>?` instead of `IEnumerable<T>?`, using the collection's `Count` property instead of the LINQ `Count()` extension. This avoids multiple enumeration of lazily-evaluated sequences.
- `Constants.IndexRangeMessage` format string and its argument order were corrected so the parameter name, index, and collection count are reported in the correct positions.

### Fixed
- Fixed a typo in `Constants.DisposedExceptionMessage` ("alread" -> "already").

[Unreleased]: https://github.com/d20Tek/exceptions-throwif/compare/main...HEAD
