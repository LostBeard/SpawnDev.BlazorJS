#!/bin/bash
set -e

echo "Building publish version"
# Get the directory where the script is located to ensure we target the correct csproj
ScriptDir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
dotnet publish "$ScriptDir/SpawnDev.BlazorJS.Demo.csproj" --configuration Release

echo "Success"
