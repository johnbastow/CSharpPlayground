namespace DatabaseFun.Services;

public interface ILoaderService<T>
{
    IEnumerable<T>GetAllRows();
}
