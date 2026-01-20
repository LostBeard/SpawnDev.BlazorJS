@echo off

REM test project's directory name
SET "TestProjectDirName=SpawnDev.BlazorJS.Demo"

REM save the original directory
SET "OriginalDir=%CD%"

REM switch to the script's directory
cd "%~dp0"

REM switch to the test project's dirctory
cd ../%TestProjectDirName%

REM run the test project's _publish script to get a published version for testing
call _publish.bat || goto :ERROR

REM switch to the Playwright test runner project directory (where this is)
cd "%~dp0"

echo Preparing tests
dotnet restore || goto :ERROR

echo Testing Chromium
dotnet test ./PlaywrightTestRunner.csproj --no-restore -- Playwright.BrowserName=chromium || goto :ERROR

echo Testing Firefox
dotnet test ./PlaywrightTestRunner.csproj --no-restore -- Playwright.BrowserName=firefox || goto :ERROR

echo Success
REM return to original directory
CD /D "%OriginalDir%"
exit /b 0

:ERROR
echo Failed
REM return to original directory
CD /D "%OriginalDir%"
exit /b 1
