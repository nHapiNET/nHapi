set BASE=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20
set MSBUILD=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBUILD.exe
set HL7DB=C:\Checkouts\duane\nHapi_superclean\nhapi\NHapi20\hl7_72_HQ.mdb
cd %BASE%
c:
cd modelgenerator
cd bin
cd debug
modelgenerator.exe /BasePath=%BASE% /Version=2.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.2 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.3 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.3.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.4 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.5 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.5.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.6 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.7 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.7.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.8 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

modelgenerator.exe /BasePath=%BASE% /Version=2.8.1 /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%HL7DB%;"

cd %BASE%
%msbuild% Hl7Models.sln
pause
