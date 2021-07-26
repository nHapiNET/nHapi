[![Build Status](https://github.com/nHapiNET/nHapi/workflows/Build%20Status/badge.svg)](https://github.com/nHapiNET/nHapi/actions?query=workflow%3A%22Build+Status%22+branch%3Amaster)
[![Codacy Badge](https://app.codacy.com/project/badge/Coverage/f2aae2999d2e43a1a759b9ffbe5a85ee)](https://www.codacy.com/gh/nHapiNET/nHapi/dashboard?utm_source=github.com&utm_medium=referral&utm_content=nHapiNET/nHapi&utm_campaign=Badge_Coverage)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/f2aae2999d2e43a1a759b9ffbe5a85ee)](https://www.codacy.com/gh/nHapiNET/nHapi/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=nHapiNET/nHapi&amp;utm_campaign=Badge_Grade)

# nHapi
NHapi is a .NET port of the original Java project [HAPI](https://github.com/hapifhir/hapi-hl7v2).

NHapi allows Microsoft .NET developers to easily use an HL7 2.x object model. This object model allows for parsing and encoding HL7 2.x data to/from Pipe Delimited or XML formats. A very handy program for use in the health care industry.

This project is **NOT** affiliated with the HL7 organization. This software just conforms to the HL7 2.x specifications.

**Key Benefits**

- Easy object model  
- Microsoft .NET 3.5 and netstandard2.0 library that conforms to HL7 2.1, 2.2, 2.3, 2.3.1, 2.4, 2.5, 2.5.1, 2.6, 2.7, 2.7.1, 2.8 and 2.8.1 specifications  
- Can take a pipe delimited or XML formatted HL7 2.x message and build the C# object model for use in code  
- Can take the C# HL7 object model and produce pipe delimited or XML formatted HL7  
- FREE! (You can't beat that price) and open source  
- Fast  

## Requirements

NHapi currently targets .NET Framework 3.5 and netstandard2.0 which aims to provide support for projects which target .NET Framework 3.5 and above as well as .NET Core 2.0 and above.

## Getting Started

The easiest way to get started using nHapi is to use the [NuGet package 'nHapi'](https://www.nuget.org/packages/nHapi/):

### Package Manager Console
Using the package manager console within visual studio, simply run the following command:

```shell
PM > Install-Package nhapi
```

### .NET CLI
From your console of choice assuming you have dotnet core installed.
```shell
> dotnet add package nhapi
```
For more options please read the [Getting Started](https://github.com/nHapiNET/nHapi/wiki/Getting-Started) page of the wiki.

## Change Log
### nHapi 3.0.0 Announcement
nHapi 3.0.0 has been officially released, the main change for this release is support for netstandard2.0, but it also has other enhancements and bug fixes.
Please read the change log below for full details of and how they might affect you prior to upgrading.

[Full Change Log](https://github.com/nHapiNET/nHapi/blob/master/CHANGELOG.md).

## Related Projects

If you use nHapi you may find the following projects useful:

- [NHapiTools](https://github.com/dib0/NHapiTools) - Many useful extension methods, helper methods for listening on MLLP/TCP, generating ACK messages, custom segments, validation rules, too many features to list here.
- [HL7Fuse](https://github.com/dib0/HL7Fuse) - HL7 Message Hub / Integration Engine
- [HL7-dotnetcore](https://github.com/Efferent-Health/HL7-dotnetcore) - Lightweight library for building and parsing HL7 2.x messages, for .Net Standard and .Net Core. It is not tied to any particular version of HL7 nor validates against one.
- [Reimers IHE Communication](https://github.com/jjrdk/reimers.ihe) - Provides support for both client side and server side HL7 transaction management.

Should you know of any other projects that use or improve nHapi please let me know or send a pull request with a link to the project and I'll be happy to add it to the list.
