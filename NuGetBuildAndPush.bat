@echo off

rem Run this script after building the Release configuration.
rem Make sure to enter the correct version number and NuGet 
rem API KEY


echo --------------------------------------------------------
echo Building package
echo --------------------------------------------------------

.\packages\NuGet.CommandLine.5.7.0\tools\NuGet.exe  pack .\CDS.CSharpScripting\CDS.CSharpScripting.csproj -Prop Configuration=Release



echo --------------------------------------------------------
echo Get user info
echo --------------------------------------------------------

set /p ver="Enter version: "
set /p api_key="Enter api_key: "
choice /M "Push the package?"
IF ERRORLEVEL 2 goto done

echo --------------------------------------------------------
echo pushing
echo --------------------------------------------------------

echo .\packages\NuGet.CommandLine.5.7.0\tools\NuGet.exe push CDS.CSharpScripting.%ver%.nupkg %api_key% -Source https://api.nuget.org/v3/index.json


:done

echo --------------------------------------------------------
echo done
echo --------------------------------------------------------


pause
