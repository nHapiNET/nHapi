properties {
    $projectName = "NHapi20"
    $unitTestAssembly = "NHapi.NUnit.dll"
    $projectConfig = "Release"
    $base_dir = resolve-path .\
    $test_dir = "$base_dir\NHapi.NUnit\bin\$projectConfig"
    $nunitPath = "$base_dir\packages\NUnit.ConsoleRunner.3.10.0\tools"
    $projects = (
        "NHapi.Base",
        "NHapi.Model.V21",
        "NHapi.Model.V22",
        "NHapi.Model.V22_ZSegments",
        "NHapi.Model.V23",
        "NHapi.Model.V24",
        "NHapi.Model.V25",
        "NHapi.Model.V26",
        "NHapi.Model.V27",
        "NHapi.Model.V28",
        "NHapi.Model.V231",
        "NHapi.Model.V251",
        "NHapi.Model.V271",
        "NHapi.Model.V281"
    )
}

Task Default -depends Build

Task Clean {
	Remove-Item *.nupkg
    Remove-Item ..\NuGet\net35\*.* -ErrorAction Ignore
    Remove-Item ..\NuGet\netstandard2.0\*.* -ErrorAction Ignore

    Get-ChildItem -inc bin -rec | Remove-Item -rec -force
    Get-ChildItem -inc obj -rec | Remove-Item -rec -force
}

Task Build -depends Clean {
	Write-Host "Building Hl7Models.sln" -ForegroundColor Green
    Exec { dotnet build "Hl7Models.sln" -c $projectConfig -v q }
}

Task BuildModels {
#    Exec { dotnet build "Hl7Models.sln" -c Debug -v q }
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.2 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.3 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.3.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.4 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.5 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.5.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.6 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.7 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.7.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.8 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\netcoreapp3.1\ModelGenerator.exe /BasePath . /Version 2.8.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
}

task Test {
    # the below nunit runner runs against dotnet framework 461
	exec {
		& $nunitPath\nunit3-console.exe $test_dir\net461\$unitTestAssembly --result="$base_dir\TestResult.xml;format=nunit2"
	}

    # TODO: Move to using dotnet test to execute the unit tests
    # the below works however the output format needs to be tweeked.
    #exec { dotnet test .\NHapi.NUnit\NHapi.NUnit.csproj -c Release -f net461 }
    exec { dotnet test .\NHapi.NUnit\NHapi.NUnit.csproj -c Release -f netcoreapp3.1 }
}

Task Package -depends Build {

    Remove-Item ..\NuGet\net35\*.* -ErrorAction Ignore
    Remove-Item ..\NuGet\netstandard2.0\*.* -ErrorAction Ignore

    New-Item -ItemType directory -Force -Path ..\NuGet\net35
    New-Item -ItemType directory -Force -Path ..\NuGet\netstandard2.0

    foreach($project in $projects) {
        Copy-Item ".\$project\bin\Release\net35\*.dll" ..\NuGet\net35
        Copy-Item ".\$project\bin\Release\net35\*.xml" ..\NuGet\net35

        Copy-Item ".\$project\bin\Release\netstandard2.0\*.dll" ..\NuGet\netstandard2.0
        Copy-Item ".\$project\bin\Release\netstandard2.0\*.xml" ..\NuGet\netstandard2.0
    }

	Exec { .nuget\nuget pack ..\NuGet\nHapi.v2.nuspec }
}

Task Deploy -depends Package {
	Exec { .nuget\nuget push *.nupkg -Source https://api.nuget.org/v3/index.json }
}