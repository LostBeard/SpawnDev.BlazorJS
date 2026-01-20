#!/bin/bash
set -e

# test project's directory name
TestProjectDirName="SpawnDev.BlazorJS.Demo"

export TestProjectDirName="$TestProjectDirName"

# save the original directory
OriginalDir=$(pwd)

# save this script's directory
ScriptDir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# switch to the script's directory
cd "$ScriptDir"

# switch to the test project's dirctory
cd ../$TestProjectDirName

# run the test project's _publish script to get a published version for testing
bash ./_publish.sh

# switch to the Playwright test runner project directory (where this is)
cd "$ScriptDir"

echo "Preparing tests"
dotnet restore

echo "Testing Chromium"
dotnet test ./PlaywrightTestRunner.csproj --no-restore -- Playwright.BrowserName=chromium

echo "Testing Firefox"
dotnet test ./PlaywrightTestRunner.csproj --no-restore -- Playwright.BrowserName=firefox

echo "Success"

# return to original directory
cd "$OriginalDir"
