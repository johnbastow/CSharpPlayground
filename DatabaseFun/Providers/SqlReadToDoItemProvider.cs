// dotnet add package System.Data.SqlClient
// dotnet add package dapper  

using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper;
using DatabaseFun.Models;

namespace DatabaseFun.Providers;

public class SqlReadToDoItemProvider : SqlReadProviderBase<ToDoItem>
{
    public SqlReadToDoItemProvider(
        ILogger<SqlReadToDoItemProvider> logger,
        string connectionString):base(logger, connectionString){}

    public override ToDoItem GetRecord()
    {
        if (this._connection is null){
            this._connection = new SqlConnection(this._connectionString);
        }
        
        if (this._reader is null){
            this._reader = this._connection.Query<ToDoItem>("SELECT * FROM tblToDoItems").GetEnumerator();
            if (!this._reader.MoveNext()){
                return null;
            }
        }

        var current = this._reader.Current;
        this._reader.MoveNext();

        return current;
    }
}
