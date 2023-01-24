# Change Log

All notable changes to this project will be documented in this file.

## Upcoming Release

## [3.X.X] - TBC

## Previous Releases

## [3.2.2] - 2023-01-24

This release is purely superficial, it does not fix or add anything.

- Add appropriate [target framework](https://learn.microsoft.com/en-us/nuget/reference/target-frameworks) metadata to the metapackage nuspec - already exists in the individual nuget packages.

See [3.2.0](#320---2023-01-20) release for latest changes.

By @milkshakeuk

## [3.2.0] - 2023-01-20

Various new `ParserOptions` have been added, see the [wiki](https://github.com/nHapiNET/nHapi/wiki/Parser-Options) for more information.

### Things of note

As part of [#398](https://github.com/nHapiNET/nHapi/pull/398) the imperfect behaviour of `XmlParser` and `DefaultXmlParser` have been updated and brought inline with `hapi` fixing many quirks and defects. If you are dependant on this old behaviour you can use `LegacyXmlParser` and `LegacyDefaultXmlParser` instead, these will be available until the next major version of `nHapi`.

The [nHapi](https://www.nuget.org/packages/nhapi) convenience nuget package is now a meta package meaning it does not directly contain any Dlls. This metapackage just describes its dependencies, which happen to be all of the individual nHapi nuget packages. If you want to understand a little bit more about metapackages [read this](https://andrewlock.net/what-is-the-microsoft-aspnetcore-metapackage/).

There is no difference in behaviour when using this metapackage vs the previous nHapi nuget package.

### Bug Fixes

- [#318](https://github.com/nHapiNET/nHapi/pull/318) Port `ORL_O34` fix for cyclic reference, fixes for `V2.5.1`, `2.5`, `2.6`. By @milkshakeuk (fixes [#298](https://github.com/nHapiNET/nHapi/issues/298))
- [#340](https://github.com/nHapiNET/nHapi/pull/340) Fix `Terser` Regex bug. By @milkshakeuk (fixes [#319](https://github.com/nHapiNET/nHapi/issues/319))
- [#402](https://github.com/nHapiNET/nHapi/pull/402) Fix `OBX` repeat counts for V24. By @milkshakeuk (fixes [#341](https://github.com/nHapiNET/nHapi/issues/341))

### Enhancements

- [#283](https://github.com/nHapiNET/nHapi/pull/283) Enable refactor of Source Generation code. By @milkshakeuk
- [#291](https://github.com/nHapiNET/nHapi/pull/291) Fix some static analysis issues. By @PhantomGrazzler
- [#308](https://github.com/nHapiNET/nHapi/pull/308) Include the optional `LongName` attribute in the XML encoded output. By @laxmi-lal-menaria (resolves [#301](https://github.com/nHapiNET/nHapi/issues/301))
- [#360](https://github.com/nHapiNET/nHapi/pull/360) Add Support for `CharSetUtil` and `PreParser`. By @milkshakeuk (resolves [#312](https://github.com/nHapiNET/nHapi/issues/312))
- [#362](https://github.com/nHapiNET/nHapi/pull/362) Fixed some static analysis warnings related to public constants. By @PhantomGrazzler
- [#398](https://github.com/nHapiNET/nHapi/pull/398) Bring XmlParsing in line with `hapi`. By @milkshakeuk (unblocks [#308](https://github.com/nHapiNET/nHapi/pull/308))
- [#278](https://github.com/nHapiNET/nHapi/issues/278) Better Source Link Support. By @milkshakeuk

### Other

- [#288](https://github.com/nHapiNET/nHapi/pull/288) Update Github Actions to use OS matrix. By @milkshakeuk

## [3.1.1] - 2022-02-19

### Enhancements

- [#277](https://github.com/nHapiNET/nHapi/pull/277) Remove MaxRepetition check, keeps nhapi in line with hapi behaviour, nhapi becomes more forgiving in regards to repetitions. By @milkshakeuk (fixes [#276](https://github.com/nHapiNET/nHapi/issues/276))

## [3.1.0] - 2022-01-01

### Enhancements

- [#254](https://github.com/nHapiNET/nHapi/pull/254) Add `UnexpectedSegmentBehaviour` Options, ported from hapi. By @milkshakeuk
- [#251](https://github.com/nHapiNET/nHapi/pull/251) Fix concurrency issues with `PipeParser`, `StructureDefinition`, `GenericMessage` and `Escape`. By @milkshakeuk
- [#250](https://github.com/nHapiNET/nHapi/pull/250) Add new options `DefaultObx2Type` and `InvalidObx2Type` to `ParserOptions`, ported from nhapi. By @milkshakeuk (fixes [#63](https://github.com/nHapiNET/nHapi/issues/63))
- [#240](https://github.com/nHapiNET/nHapi/pull/240) Add support for `NonGreedyMode` by introducing `ParserOptions` ported from hapi. By @PhantomGrazzler (fixes [#65](https://github.com/nHapiNET/nHapi/issues/65) [#232](https://github.com/nHapiNET/nHapi/issues/232))

### Other

- [#256](https://github.com/nHapiNET/nHapi/pull/256) Simplify cspoj through use of props and targets files. By @milkshakeuk
- Update tools and build to net6.0. By @milkshakeuk

## [3.0.4] - 2021-08-11

This change is to prevent the following Exception:

> System.ArgumentException - An item with the same key has already been added.

In cases where dictionaries / hashtables are used for lookups such as `Escape.cs` when there multiple threads trying to add to them at the same time.

Instead of using `Add(key, value)` which only allows 1 items with a given key to be added to the dictionary / hashtable, we are using the index accessor to set or update the value in a last one wins scenario, but only when its combined with `ContainsKey` which has indicated that an item with that key shouldn't exist.

By @milkshakeuk

## [3.0.3] - 2021-08-10

This change updates the `PipeParser` Version check when obtaining encoding characters from a message object in order to encode it to HL7; `string.CompareOrdinal` is now used instead of `System.Version` which is more forgiving when a version contains non numerical characters.

By @milkshakeuk

## [3.0.2] - 2021-08-09

This change gives nhapi [strong-named assemblies](https://docs.microsoft.com/en-us/dotnet/standard/assembly/strong-named), there are no codes changes.

### Bug Fixes

- [#227](https://github.com/nHapiNET/nHapi/issues/227) fixes "A strongly-named assembly is required" runtime errors

By @milkshakeuk

## [nhapi.model.v231 3.0.1] - 2021-07-02

This release is for the NuGet package `nhapi.model.v231` only, there are no code changes, see below for change.

- Remove unused project reference.

## [3.0.0] - 2021-06-28

Along with the changes below you can now be more selective about how you install nHapi, please read the [Getting Started](https://github.com/nHapiNET/nHapi/wiki/Getting-Started#nhapi-version-300) page of the wiki for more information.

### Breaking Changes

Default escape sequence for carriage return has changed from `\X000d\` to `\X0D\` which brings it inline with other libraries and [InterSystems ensemble](https://docs.intersystems.com/latest/csp/docbook/Doc.View.cls?KEY=EHL72_escape_sequences).

However if you rely on the old escape sequence of `\X000d\` for carriage returns you can now configure this, see [#185](https://github.com/nHapiNET/nHapi/pull/185) or the [wiki](https://github.com/nHapiNET/nHapi/wiki/Configuration-Options) for configuration options.

The latest `PipeParser` implementation from hapi has been ported over to nHapi, there aren't any breaking changes that I am aware of, only benefits, however if you relied on the specific behaviour of the old `PipeParser.cs` then you can use `LegacyPipeParser.cs` instead, which is the old implementation.

### Bug Fixes

- [#118](https://github.com/nHapiNET/nHapi/pull/118) Add LongDateTimeFormatWithFactionOfSecond format for date parsing (fixes [#104](https://github.com/nHapiNET/nHapi/issues/104))
- [#134](https://github.com/nHapiNET/nHapi/pull/134) Fix spelling mistake
- [#136](https://github.com/nHapiNET/nHapi/pull/136) Various Issue fixes (fixes for [#45](https://github.com/nHapiNET/nHapi/issues/45), [#62](https://github.com/nHapiNET/nHapi/issues/62), [#81](https://github.com/nHapiNET/nHapi/issues/81), [#84](https://github.com/nHapiNET/nHapi/issues/84), [#85](https://github.com/nHapiNET/nHapi/issues/85), [#86](https://github.com/nHapiNET/nHapi/issues/86), [#109](https://github.com/nHapiNET/nHapi/issues/109), [#133](https://github.com/nHapiNET/nHapi/issues/133))
- [#185](https://github.com/nHapiNET/nHapi/pull/185) `Escape.cs` Improvements - hapi implementation port. (fixes for [#103](https://github.com/nHapiNET/nHapi/issues/103))
- [#192](https://github.com/nHapiNET/nHapi/pull/192), [#202](https://github.com/nHapiNET/nHapi/pull/202) Update HL7 v. 2.3 IN1 and IN2 repeat flags for some fields. (fixes [#191](https://github.com/nHapiNET/nHapi/issues/191))
- [#200](https://github.com/nHapiNET/nHapi/pull/200) PipeParser Enhancements - Fix issues related to unexpected segments. (fixes [#51](https://github.com/nHapiNET/nHapi/issues/51), [#55](https://github.com/nHapiNET/nHapi/issues/55), [#56](https://github.com/nHapiNET/nHapi/issues/56), [#72](https://github.com/nHapiNET/nHapi/issues/72), [#101](https://github.com/nHapiNET/nHapi/issues/101))
- [#197](https://github.com/nHapiNET/nHapi/pull/197) Fixes Exceptions and permanent Hang when parsing bad input, Adds bad input tests. (fixes [#196](https://github.com/nHapiNET/nHapi/issues/196), [#198](https://github.com/nHapiNET/nHapi/issues/198))
- [#205](https://github.com/nHapiNET/nHapi/pull/205) Added additional bad inputs and enhanced error handling. (fixes [#203](https://github.com/nHapiNET/nHapi/issues/203))
- [#217](https://github.com/nHapiNET/nHapi/pull/217) Add changes to fix bad input from fuzzing. (fixes [#210](https://github.com/nHapiNET/nHapi/issues/210))

### Enhancements

- [#75](https://github.com/nHapiNET/nHapi/pull/75) Add support for removing fields by index or by item/type
- [#112](https://github.com/nHapiNET/nHapi/pull/112) Adds support for netstandard2.0. (fixes [#61](https://github.com/nHapiNET/nHapi/issues/61))

### Other

- [#117](https://github.com/nHapiNET/nHapi/pull/117) Add .vs into .gitignore file to ignore Visual Studio files
- [#129](https://github.com/nHapiNET/nHapi/pull/129) restructure project to a more modern project structure
- [#130](https://github.com/nHapiNET/nHapi/pull/130) Decouple NHapi source code generation from NHapi.Base
- [#135](https://github.com/nHapiNET/nHapi/pull/135) NHapi.Base > Formatted XML License Comments
- [#135](https://github.com/nHapiNET/nHapi/pull/135), [#137](https://github.com/nHapiNET/nHapi/pull/137) Fix XML Build warnings. (fixes [#128](https://github.com/nHapiNET/nHapi/issues/128))
- [#140](https://github.com/nHapiNET/nHapi/pull/140) Add license for nHapi. (fixes [#119](https://github.com/nHapiNET/nHapi/issues/119))
- [#143](https://github.com/nHapiNET/nHapi/pull/143) Add StyleCopAnalyzers to main projects. (fixes [#138](https://github.com/nHapiNET/nHapi/issues/138))
- [#141](https://github.com/nHapiNET/nHapi/pull/141) Create basic GitHub Actions for pull requests. (partially addresses [#124](https://github.com/nHapiNET/nHapi/issues/124))
- [#142](https://github.com/nHapiNET/nHapi/pull/142) Add code coverage to the CI/CD, plus build status workflow for master. (partially addresses [#124](https://github.com/nHapiNET/nHapi/issues/124))
- [#145](https://github.com/nHapiNET/nHapi/pull/145) Code Climate Coverage. (partially addresses [#124](https://github.com/nHapiNET/nHapi/issues/124))
- [#147](https://github.com/nHapiNET/nHapi/pull/147), [#148](https://github.com/nHapiNET/nHapi/pull/148) Enable dependabot support to the repository
- [#201](https://github.com/nHapiNET/nHapi/pull/201) Normalize all the line endings.
- [#204](https://github.com/nHapiNET/nHapi/pull/204) Create Default GitHub Code Scanning Workflow

## [3.0.0-preview.3] - 2021-06-02

<https://github.com/nHapiNET/nHapi/releases/tag/v3.0.0-preview.3>

## [3.0.0-preview.2] - 2021-01-30

<https://github.com/nHapiNET/nHapi/releases/tag/v3.0.0-preview.2>

## [3.0.0-preview.1] - 2020-11-02

<https://github.com/nHapiNET/nHapi/releases/tag/v3.0.0-preview.1>

## [2.5.0.6] - 2016-09-13

### Fixes

- Resolve #11 by reverting:
  - "Fix pipe parser and message iterator in handing white space in version and unexpected segments"
  - "Add unknown segments to the message not child groups."
  - "Fix pipe parser segment rep, and invalid field reps."
  - "Fix rep code to actually read using the GetField(i, rep)"

## [2.5.0.5] - 2016-07-27

### Fixes

- If encountering a DTM typed OBX result in a version of HL7 that does not have the DTM type, redirect to the DT type

## [2.5.0.4] - 2016-07-15

### Fixes  (Submitted by dib0)

- Small bug in milliseconds parsing CommonTM.cs #48

## [2.5.0.3] - 2016-07-15

### Fixes  (Submitted by Eric-Cadwell)

- TSComponentOne GetAsDate does not handle offset from UTC/GMT #38
- Whitespace after version number causes an issue #39
- Unexpected Segments cause later parsing issues #40
- Message escaping isn't functioning properly on all UNC strings #44

## [2.5.0.2] - 2016-07-15

### Added

- All versions: Repeating structures now have Enumerators, Add, Remove and RemoveAt methods generated

## [2.5.0.1] - 2016-07-14

### Breaking Changes

- Many breaking changes for v2.2, v2.3 and v2.3.1.  These are all due to fields not correctly being repeating or single fields, incorrect data types etc.
- All versions now successfully able to be code generated once more.

## [2.4.0.20] - 2016-07-13

### Added

- Initial implementation for HL7 version 2.8.1

## [2.4.0.19] - 2016-07-13

### Added

- Initial implementation for HL7 version 2.8

## [2.4.0.18] - 2016-07-13

### Added

- Initial implementation for HL7 version 2.7.1

## [2.4.0.17] - 2016-07-12

### Added

- Initial implementation for HL7 version 2.7

## [2.4.0.16] - 2016-07-12

### Added

- Initial implementation for HL7 version 2.6

## [2.4.0.15] - 2016-06-10

### Fixed

- Restore original behaviour for Custom Segment handling as reported in issue #28 (Submitted by lniedzielski)

## [2.4.0.14] - 2016-06-09

### Fixed

- Fix nHapi v2.5.1 not mapping ADT events correctly due to lack of having an eventmapping.properties embedded in the project (Submitted by rajputs6)

## [2.4.0.13] - 2016-05-19

### Fixed

- Fix incorrect version for all dlls
- Fix NHapi.Model.V251.dll not having it's version property set correctly

## [2.4.0.12] - 2016-04-06

### Fixed

- Add xml comments to nuget package (Submitted by vongillern)

## [2.4.0.11] - 2015-04-23

### Fixed

- HL7 Version 2.5.1 messages would not parse due to having incorrect namespaces.  Affected segments "DT, ST and TM". (Reported by lharless)

## [2.4.0.10] - 2015-03-15

### Fixed

- HL7 Version 2.1 messages would not parse due to not being listed as an acceptable base version. (Reported by taiji123)

## [2.4.0.9] - 2015-03-03

### Fixed

- Catch unhandled InvalidOperationExceptions when populating a HL7Exception's ERR segment using HL7Exception.populate().

## [2.4.0.8] - 2015-03-02

### Fixed

- Resolve EventMaps not being loaded properly.
- Update FT's SizeRule to be up to 64k in length.
- Include field offset component when rethrowing caught DataTypeExceptions whilst parsing.

## [2.4.0.7] - 2015-02-21

### Fixed

- Abstract and Varies segments were not having their Description field values populated. (Reported bv TheStephenStanton)

## [2.4.0.6] - 2015-02-21

### Fixed

- ORU_R01 messages for v2.5.1 incorrectly did not support the repeating, optional segments OBX, Timing QTY and Specimen.
- Moved regular expression field validation into it's own StrictValidation opt in validation context.
- Correctly escape \X0A\ as \n (thanks to riaz.ahmad)
- Each field / token was being extracted twice (Reported by AFAde)

## [2.4.0.5] - 2015-02-19

### Fixed

- Nuget Package wasn't deploying the 2.51 dll due to new nuget command line packaging and deployment.
