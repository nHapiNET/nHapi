properties {
    $projectName = "NHapi20"
    $unitTestAssembly = "NHapi.NUnit.dll"
    $projectConfig = "Release"
    $base_dir = resolve-path .\
    $test_dir = "$base_dir\..\tests\NHapi.NUnit\bin\$projectConfig"
    $nunitPath = "$base_dir\packages\NUnit.ConsoleRunner.3.10.0\tools"
    $projects = (
        "NHapi.Base",
        "NHapi.Model.V21",
        "NHapi.Model.V22",
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
    $apiKey = "YOUR_API_KEY"
}

Task Default -depends Build

Task Clean {
	Remove-Item ..\dist\*.nupkg
    Remove-Item ..\dist\net35\*.* -ErrorAction Ignore
    Remove-Item ..\dist\netstandard2.0\*.* -ErrorAction Ignore

    Get-ChildItem -path ..\ -inc bin -rec | Remove-Item -rec -force
    Get-ChildItem -path ..\ -inc obj -rec | Remove-Item -rec -force
}

Task Build -depends Clean {
	Write-Host "Building nHapi.sln" -ForegroundColor Green
    Exec { dotnet build "..\nHapi.sln" -c $projectConfig -v q }
}

Task BuildModels {
#    Exec { dotnet build "nHapi.sln" -c Debug -v q }
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
    exec { dotnet test ..\tests\NHapi.NUnit\NHapi.NUnit.csproj -r TestResults -c Release -f net461 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.Base.NUnit\NHapi.Base.NUnit.csproj -r TestResults -c Release -f net461 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit.SourceGeneration\NHapi.NUnit.SourceGeneration.csproj -r TestResults -c Release -f net461 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit.SourceGeneration\NHapi.NUnit.SourceGeneration.csproj -r TestResults -c Release -f net6.0 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit\NHapi.NUnit.csproj -r TestResults -c Release -f net6.0 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.Base.NUnit\NHapi.Base.NUnit.csproj -r TestResults -c Release -f net6.0 --no-restore --no-build }
}

Task Package -depends Build {

    Remove-Item ..\dist\net35\*.* -ErrorAction Ignore
    Remove-Item ..\dist\netstandard2.0\*.* -ErrorAction Ignore

    New-Item -ItemType directory -Force -Path ..\dist\net35
    New-Item -ItemType directory -Force -Path ..\dist\netstandard2.0

    foreach($project in $projects) {
        Copy-Item "..\src\$project\bin\$projectConfig\net35\*.dll" ..\dist\net35
        Copy-Item "..\src\$project\bin\$projectConfig\net35\*.xml" ..\dist\net35

        Copy-Item "..\src\$project\bin\$projectConfig\netstandard2.0\*.dll" ..\dist\netstandard2.0
        Copy-Item "..\src\$project\bin\$projectConfig\netstandard2.0\*.xml" ..\dist\netstandard2.0
    }

	Exec { .nuget\nuget pack .\nHapi.v3.nuspec -OutputDirectory ..\dist }

    foreach($project in $projects) {
        Exec { dotnet pack "..\src\$project\$project.csproj" -c $projectConfig --no-build --no-restore -o "..\dist" }
    }
}

Task Deploy -depends Package {

    foreach($project in $projects) {
        Exec { dotnet nuget push "..\dist\$project.*.nupkg" --api-key $apiKey }
    }

    Exec { dotnet nuget push "..\dist\nhapi.3.1.0.nupkg" --api-key $apiKey }
	# Exec { .nuget\nuget push *.nupkg -Source https://api.nuget.org/v3/index.json }
}