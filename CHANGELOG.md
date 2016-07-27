# Change Log
All notable changes to this project will be documented in this file.

## Upcoming Release
###
-

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
