
using System.Data;
using DatabaseFun.Providers;

namespace DatabaseFun.Services;

public class LoaderService<T>(IRecordReadProvider<T> recordProvider) : ILoaderService<T>
{
    private IRecordReadProvider<T>  _recordProvider = recordProvider;

    public IEnumerable<T> GetAllRows()
    {
        List<T> allRows = new List<T>();

        T row = this._recordProvider.GetRecord();

        while (row != null){
            allRows.Add(row);
        }

        return allRows;
    }
}
