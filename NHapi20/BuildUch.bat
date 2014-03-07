set BASE=D:\Projects\NHapi\SourceForge\NHapi20
set MSBUILD=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\MSBUILD.exe
cd %BASE%
d:
cd modelgenerator
cd bin
cd debug
modelgenerator.exe /BasePath=%BASE% /Version=2.3.UCH /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\projects\hl7\hl7db.mdb;"

modelgenerator.exe /BasePath=%BASE% /Version=2.5.UCH /ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Z:\projects\hl7\hl7db_v25Uch.mdb;"

cd %BASE%
%msbuild% UCH.sln

