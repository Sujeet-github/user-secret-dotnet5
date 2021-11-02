# user-secret-dotnet5
Implement to hide key using user-secret and health check service 

commands :
dotnet user-secrets init
> this will getnerate userid key into project (.csproj) file
> now add key which need to hide using below command
dotnet user-secrets set ServiceSettings:ApiKey values

register class into Startup.cs file

