if ((Test-Path .\build)) { Remove-AllChildItems -r -fo .\build }
New-Item -ItemType Directory .\build | Out-Null
dotnet build -c release
Copy-Item -r .\Liftoff.Config\bin\Release\*.nupkg .\build
Copy-Item -r .\Liftoff.Logging\bin\Release\*.nupkg .\build
