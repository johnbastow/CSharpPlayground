using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Logging;

namespace DatabaseFun.Providers;

public class CsvReadProvider<T> : IRecordReadProvider<T>, IDisposable
{
    private ILogger<CsvReadProvider<T>> _logger { get; init; }
    private StreamReader _reader { get; init; }
    private CsvReader _csvReader { get; init; }

    public CsvReadProvider(ILogger<CsvReadProvider<T>> logger, string filePath){
            this._reader = new StreamReader(filePath);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture){
                NewLine = Environment.NewLine
                // PrepareHeaderForMatch = args => args.Header.ToLower()
            };
            this._csvReader = new CsvReader(this._reader, csvConfig);
            this._csvReader.Read();
            this._csvReader.ReadHeader();
    }

    public T GetRecord()
    {
        if(!this._csvReader.Read()) return default(T);

        return this._csvReader.GetRecord<T>();
    }

    public void Dispose()
    {
        this._csvReader.Dispose();
        this._reader.Dispose();
    }
}
