
SET "OriginalDir=%CD%"

cd "%~dp0"

echo Building...
cd ../SpawnDev.BlazorJS.Demo
call _publish.bat || goto :ERROR

cd "%~dp0"

echo Preparing tests
dotnet restore || goto :ERROR

echo Testing Chromium
dotnet test ./SpawnDev.BlazorJS.Tests.csproj --no-restore -- Playwright.BrowserName=chromium || goto :ERROR

echo Testing Firefox
dotnet test ./SpawnDev.BlazorJS.Tests.csproj --no-restore -- Playwright.BrowserName=firefox || goto :ERROR

echo Success
CD /D "%OriginalDir%"
exit /b 0

:ERROR
echo Failed
CD /D "%OriginalDir%"
exit /b 1
