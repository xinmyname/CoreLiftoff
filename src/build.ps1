if ((Test-Path .\build)) { Remove-AllChildItems -r -fo .\build }
New-Item -ItemType Directory .\build | Out-Null
dotnet clean -c release
gci -r -fi *.nupkg |% { $_.Delete() }
dotnet build -c release
Copy-Item -r .\Liftoff.Config\bin\Release\*.nupkg .\build
Copy-Item -r .\Liftoff.Logging\bin\Release\*.nupkg .\build
Copy-Item -r .\Liftoff.Service\bin\Release\*.nupkg .\build
