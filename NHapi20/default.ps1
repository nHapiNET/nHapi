Task Default -depends Build

Task Build {
	Write-Host "Building Hl7Models.sln" -ForegroundColor Green
	Exec { msbuild "Hl7Models.sln" /t:Build /p:Configuration=Release /v:quiet} 
}

Task Deploy -depends Build {
	Remove-Item ..\NuGet\*.dll
	Copy-Item .\NHapi.NUnit\bin\Release\*.dll ..\NuGet
	Exec { .nuget\nuget pack ..\NuGet\nHapi.v2.nuspec }
	Exec { .nuget\nuget push *.nupkg }
}