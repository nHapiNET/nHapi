Task Default -depends Build

Task Clean {
	Remove-Item *.nupkg
	Remove-Item ..\NuGet\*.dll
}

Task Build -depends Clean {
	Write-Host "Building Hl7Models.sln" -ForegroundColor Green
	Exec { msbuild "Hl7Models.sln" /t:Build /p:Configuration=Release /v:quiet} 
}

Task BuildModels {
    Exec { msbuild "Hl7Models.sln" /t:Build /p:Configuration=Debug /v:quiet}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.2 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.3 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.3.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.4 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.5 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.5.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.6 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.7 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.7.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.8 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
#    Exec { ModelGenerator\Bin\Debug\ModelGenerator.exe /BasePath=. /Version=2.8.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb;"}
}

Task Package -depends Build {
	Remove-Item ..\NuGet\*.dll
	Copy-Item .\NHapi.NUnit\bin\Release\*.dll ..\NuGet
	Exec { .nuget\nuget pack ..\NuGet\nHapi.v2.nuspec }
}

Task Deploy -depends Package {
	Exec { .nuget\nuget push *.nupkg }
}