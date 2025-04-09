properties {
    $unitTestAssembly = "NHapi.NUnit.dll"
    $projectConfig = "Release"
    $base_dir = ".\"
    $test_dir = "$base_dir\..\tests\NHapi.NUnit\bin\$projectConfig"
    $nunitPath = "$base_dir\packages\NUnit.ConsoleRunner.3.20.0\tools"
    $projects = @(
        "NHapi.Base",
        "NHapi.Model.V21",
        "NHapi.Model.V22",
        "NHapi.Model.V23",
        "NHapi.Model.V231",
        "NHapi.Model.V24",
        "NHapi.Model.V25",
        "NHapi.Model.V251",
        "NHapi.Model.V26",
        "NHapi.Model.V27",
        "NHapi.Model.V271",
        "NHapi.Model.V28",
        "NHapi.Model.V281"
    )
    $apiKey = "YOUR_API_KEY"
}

Task Default -depends Build

Task Clean {
    Remove-Item ..\dist\*.nupkg -ErrorAction Ignore
    Remove-Item ..\dist\*.snupkg -ErrorAction Ignore
    Remove-Item ..\dist\net35 -Recurse -ErrorAction Ignore
    Remove-Item ..\dist\netstandard2.0 -Recurse -ErrorAction Ignore

    Get-ChildItem -path ..\ -inc bin -rec | Remove-Item -rec -force
    Get-ChildItem -path ..\ -inc obj -rec | Remove-Item -rec -force
}

Task Build -depends Clean {
    Write-Output "Building nHapi.sln" -ForegroundColor Green
    Exec { dotnet build "..\nHapi.sln" -c $projectConfig -v q }
}

Task BuildModels {
#    Exec { dotnet build "nHapi.sln" -c Debug -v q }
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.2 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.3 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.3.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.4 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.5 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.5.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.6 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.7 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.7.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.8 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\net8.0\ModelGenerator.exe /BasePath . /Version 2.8.1 /ConnectionString "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\hl7_72_HQ.mdb;"}
}

task Test {
    # the below nunit runner runs against dotnet framework 461
    if ($IsWindows -eq $null -Or $IsWindows){
        exec {
            & $nunitPath\nunit3-console.exe $test_dir\net462\$unitTestAssembly --result="$base_dir\TestResult.xml;format=nunit3"
        }
    }

    # TODO: Move to using dotnet test to execute the unit tests
    # the below works however the output format needs to be tweeked.
    exec { dotnet test ..\tests\NHapi.Base.NUnit\NHapi.Base.NUnit.csproj --results-directory TestResults -c Release -f net462 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit\NHapi.NUnit.csproj --results-directory TestResults -c Release -f net462 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit.SourceGeneration\NHapi.NUnit.SourceGeneration.csproj --results-directory TestResults -c Release -f net8.0 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.NUnit\NHapi.NUnit.csproj --results-directory TestResults -c Release -f net8.0 --no-restore --no-build }
    exec { dotnet test ..\tests\NHapi.Base.NUnit\NHapi.Base.NUnit.csproj --results-directory TestResults -c Release -f net8.0 --no-restore --no-build }
}

Task Package -depends Build {

    Remove-Item ..\dist\net35 -Recurse -ErrorAction Ignore
    Remove-Item ..\dist\netstandard2.0 -Recurse -ErrorAction Ignore
    Remove-Item ..\dist\*.nupkg -ErrorAction Ignore
    Remove-Item ..\dist\*.snupkg -ErrorAction Ignore

    foreach($project in $projects) {
        Exec { dotnet pack "..\src\$project\$project.csproj" -c $projectConfig --no-build --no-restore -o "..\dist" }
    }

    $commit = (git rev-parse --verify HEAD)
    $nuspec = "nHapi.v3.nuspec"

    (Get-Content $nuspec).Replace('commit=""', 'commit="' + $commit + '"') | Set-Content $nuspec

    New-Item -ItemType directory -Force -Path ..\dist\net35
    New-Item -ItemType directory -Force -Path ..\dist\netstandard2.0
    New-Item -ItemType file -Path ..\dist\net35 -Name _._
    New-Item -ItemType file -Path ..\dist\netstandard2.0 -Name _._

    if ($IsWindows -eq $null -Or $IsWindows){
        Exec { .nuget\NuGet.exe pack $nuspec -OutputDirectory ..\dist }
    }
    else
    {
        Exec { mono .nuget/NuGet.exe pack $nuspec -OutputDirectory "../dist" }
    }

    (Get-Content $nuspec).Replace('commit="' + $commit + '"', 'commit=""') | Set-Content $nuspec
}

Task Deploy -depends Package {

    foreach($project in $projects) {
        Exec { dotnet nuget push "../dist/$($project.ToLower()).*.nupkg" -k $apiKey -sk $apiKey -s "https://api.nuget.org/v3/index.json" --skip-duplicate }
    }

    Exec { dotnet nuget push "../dist/nhapi.3.*.nupkg" -k $apiKey -sk $apiKey -s "https://api.nuget.org/v3/index.json" }
}