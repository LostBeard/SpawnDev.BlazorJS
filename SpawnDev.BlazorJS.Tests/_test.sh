#!/bin/bash
set -e

OriginalDir=$(pwd)

# Switch to the script's directory
cd "$(dirname "$0")"

echo "Building..."
cd ../SpawnDev.BlazorJS.Demo
if [ -f "./_publish.sh" ]; then
    bash ./_publish.sh
else
    echo "_publish.sh not found. Running publish command directly."
    dotnet publish "./SpawnDev.BlazorJS.Demo.csproj" --configuration Release
fi

# Switch to the script's directory
cd "$(dirname "$0")"

echo "Preparing tests"
dotnet restore

echo "Testing Chromium"
dotnet test ./SpawnDev.BlazorJS.Tests.csproj --no-restore -- Playwright.BrowserName=chromium

echo "Testing Firefox"
dotnet test ./SpawnDev.BlazorJS.Tests.csproj --no-restore -- Playwright.BrowserName=firefox

echo "Success"
# Return to original directory (optional for subshell execution but good for source)
cd "$OriginalDir"
