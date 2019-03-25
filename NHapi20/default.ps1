properties {
    $projectName = "NHapi20"
    $unitTestAssembly = "NHapi.NUnit.dll"
    $projectConfig = "Release"
    $base_dir = resolve-path .\
    $test_dir = "$base_dir\NHapi.NUnit\bin\$projectConfig\net461"
    $nunitPath = "$base_dir\packages\NUnit.ConsoleRunner.3.10.0\tools"
}

Task Default -depends Build

Task Clean {
	Remove-Item *.nupkg
	Remove-Item ..\NuGet\*.dll
}

Task Build -depends Clean {
	Write-Host "Building Hl7Models.sln" -ForegroundColor Green
    Exec { dotnet msbuild "Hl7Models.sln" /t:Build /p:Configuration=$projectConfig /v:quiet}
}

Task BuildModels {
#    Exec { msbuild "Hl7Models.sln" /t:Build /p:Configuration=Debug /v:quiet}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.2 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.3 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.3.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.4 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.5 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.5.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.6 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.7 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.7.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.8 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath . /Version 2.8.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
}

task Test {
	exec {
		& $nunitPath\nunit3-console.exe $test_dir\$unitTestAssembly --result="$base_dir\TestResult.xml;format=nunit2"
	}
}

Task Package -depends Build {
	Remove-Item ..\NuGet\*.dll
	Copy-Item .\NHapi.NUnit\bin\Release\*.dll ..\NuGet
    Copy-Item .\NHapi.NUnit\bin\Release\*.xml ..\NuGet
	Exec { .nuget\nuget pack ..\NuGet\nHapi.v2.nuspec }
}

Task Deploy -depends Package {
	Exec { .nuget\nuget push *.nupkg }
}