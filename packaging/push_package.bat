
echo You are about to push this package to the package server
pause
nuget.exe push -Source https://pkgs.dev.azure.com/Seenry/Gravenger/_packaging/gravenger/nuget/v3/index.json -ApiKey key Gravenger.Domain.0.1.0.nupkg
pause