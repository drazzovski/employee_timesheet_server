- default connection string for MySql server
    appsettings.json

- migrations
    in terminal window type: "dotnet ef database update"
    if errors occurred, delete Migrations folder then type: "dotnet ef migrations add "init", and again "dotnet ef database update"