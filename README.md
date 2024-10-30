# SQL
```
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run \
    --env "ACCEPT_EULA=Y" \
    --env "MSSQL_SA_PASSWORD=Password7*test" \
    --publish 1433:1433 \
    --name sqlplayground \
    --detach \
    --rm \
    -v /Users/limeybastow/Library/CloudStorage/OneDrive-Personal/code-projects/CSharpPlayground/sqlvolumes/data:/var/opt/mssql/data \
    -v /Users/limeybastow/Library/CloudStorage/OneDrive-Personal/code-projects/CSharpPlayground/sqlvolumes/log:/var/opt/mssql/log \
    -v /Users/limeybastow/Library/CloudStorage/OneDrive-Personal/code-projects/CSharpPlayground/sqlvolumes/secrets:/var/opt/mssql/secrets \
    mcr.microsoft.com/mssql/server:2022-latest

```

```
# Install SQL Package tools via dotnet CLI.
dotnet tool install -g Microsoft.SqlPackage

# Install SQL project templates in dotnet CLI.
dotnet new install Microsoft.Build.Sql.Templates

# Create new SQL project from dotnet CLI
dotnet new sqlproj
```

```
SqlPackage /Action:Publish /SourceFile:"./ToDoSQLDB.dacpac" /TargetConnectionString:"Server=localhost;Database=ToDoDB;User Id=sa;Password=Password7*test;Encrypt=True;TrustServerCertificate=True;"


Server=localhost;Database=ToDoDB;User Id=sa;Password=Password7*test;Encrypt=True;TrustServerCertificate=True;

