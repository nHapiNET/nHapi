Task Default -depends Build

Task Build {
	Write-Host "Building Hl7Models.sln" -ForegroundColor Green
	Exec { msbuild "Hl7Models.sln" /t:Build /p:Configuration=Release /v:quiet} 
}