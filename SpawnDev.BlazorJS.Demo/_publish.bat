@echo off
echo Building publish version
dotnet publish "%~dp0/SpawnDev.BlazorJS.Demo.csproj" --configuration Release || goto :ERROR

echo Success
exit /b 0

:ERROR
echo Failed
exit /b 1