@echo off

rem Run this script after building the Release configuration.

cd .\CDS.CSharpScripting


echo --------------------------------------------------------
echo Get user info
echo --------------------------------------------------------

set /p ver="Enter version: "
set /p api_key="Enter api_key: "


echo.
echo --------------------------------------------------------
echo Refresh the nupsec package
echo --------------------------------------------------------

.\..\packages\NuGet.CommandLine.5.11.0\tools\NuGet.exe  pack CDS.CSharpScripting.csproj -Prop Configuration=Release -Version %ver%



echo.
echo --------------------------------------------------------
echo Push
echo --------------------------------------------------------

set command=.\..\packages\NuGet.CommandLine.5.7.0\tools\NuGet.exe push CDS.CSharpScripting.%ver%.nupkg %api_key% -Source https://api.nuget.org/v3/index.json
echo.
echo Push command looks like this:
echo.
echo %command%
echo.

choice /M "Push the package?"
IF ERRORLEVEL 2 goto done

echo.
echo --------------------------------------------------------
echo pushing
echo --------------------------------------------------------

echo.
%command%

:done

echo.
echo --------------------------------------------------------
echo done
echo --------------------------------------------------------


pause
