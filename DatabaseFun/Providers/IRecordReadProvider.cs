namespace DatabaseFun.Providers;

public interface IRecordReadProvider<T>
{
    T GetRecord();
}
