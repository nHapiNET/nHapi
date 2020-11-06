powershell -Command "& {Import-Module .\packages\psake.4.4.1\tools\psake.psm1; Invoke-psake .\default.ps1 Deploy %*}"
pause