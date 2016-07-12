[![Build status](https://ci.appveyor.com/api/projects/status/llfc0qjtahffnpdw?svg=true)](https://ci.appveyor.com/project/DuaneEdwards/nhapi)

# nHapi
NHapi is a .NET port of the original Java project [HAPI](http://hl7api.sourceforge.net/).

NHapi allows Microsoft .NET developers to easily use an HL7 2.x object model. This object model allows for parsing and encoding HL7 2.x data to/from Pipe Delimited or XML formats. A very handy program for use in the health care industry.

This project is **NOT** affiliated with the HL7 organization. This software just conforms to the HL7 2.x specifications.

**Key Benefits**

- Easy object model  
- Microsoft .NET 3.5 library that conforms to HL7 2.1, 2.2, 2.3, 2.3.1, 2.4, 2.5, 2.5.1 and 2.6 specifications  
- Can take a pipe delimited or XML formated HL7 2.x message and build the C# object model for use in code  
- Can take the C# HL7 object model and produce pipe delimited or XML formatted HL7  
- FREE! (You can't beat that price) and open source  
- Fast  

##Requirements

NHapi currently targets version 3.5 of the .NET Framework

##Getting Started

The easiest way to get started using nHapi is to use the [NuGet package 'nHapi'](https://www.nuget.org/packages/nHapi/):

Using the package manager console withing visual studio, simply run the following command:

```
PM > Install-Package nHapi
```

##[Change Log](https://github.com/duaneedwards/nHapi/blob/master/CHANGELOG.md)

##Related Projects

If you use nHapi you may find the following projects useful:

- [NHapiTools](https://github.com/dib0/NHapiTools) - Many useful extension methods, helper methods for listening on MLLP/TCP, generating ACK messages, custom segments, validation rules, too many features to list here.
- [HL7Fuse](https://github.com/dib0/HL7Fuse) - HL7 Message Hub / Integration Engine

Should you know of any other projects that use or improve nHapi please let me know or send a pull request with a link to the project and I'll be happy to add it to the list.
