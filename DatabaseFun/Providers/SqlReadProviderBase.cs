// dotnet add package System.Data.SqlClient
// dotnet add package dapper  

using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper;
using DatabaseFun.Models;

namespace DatabaseFun.Providers;

public abstract class SqlReadProviderBase<T>(
        ILogger<SqlReadProviderBase<T>> logger,
        string connectionString) : IRecordReadProvider<T>, IDisposable
{
    protected readonly ILogger<SqlReadProviderBase<T>> _logger = logger;
    protected readonly string _connectionString = connectionString;

    protected SqlConnection? _connection = null;

    protected IEnumerator<T>? _reader = null;

    public abstract T GetRecord();

    public void Dispose()
    {
        if (this._reader is not null)
            this._reader.Dispose();

        if (this._connection is not null)
            this._connection.Dispose();
    }
}
