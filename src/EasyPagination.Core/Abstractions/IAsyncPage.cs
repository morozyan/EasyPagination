namespace EasyPagination.Core.Abstractions;

public interface IAsyncPage<T> : IBasePage<T>
{
    Task<IAsyncPage<T>> NextPageAsync();
}