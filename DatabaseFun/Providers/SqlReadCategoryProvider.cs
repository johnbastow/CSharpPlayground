// dotnet add package System.Data.SqlClient
// dotnet add package dapper  

using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper;
using DatabaseFun.Models;

namespace DatabaseFun.Providers;

public class SqlReadCategoryProvider : SqlReadProviderBase<Category>
{
    public SqlReadCategoryProvider(
        ILogger<SqlReadCategoryProvider> logger,
        string connectionString):base(logger, connectionString){}

    public override Category? GetRecord()
    {
        if (this._connection is null){
            this._connection = new SqlConnection(this._connectionString);
        }

        var categories =  this._connection.Query<Category>("SELECT * FROM tblCategories");
        
        if (this._reader is null){
            this._reader = this._connection.Query<Category>("SELECT * FROM tblCategories").GetEnumerator();
            if (!this._reader.MoveNext()){
                return null;
            }
        }

        var current = this._reader.Current;
        this._reader.MoveNext();

        return current;
    }
}
