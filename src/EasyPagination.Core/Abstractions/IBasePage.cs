namespace EasyPagination.Core.Abstractions;

public interface IBasePage<out T>
{
    IReadOnlyList<T> Items { get; }
    IPageSettings Settings { get; }
    bool HasNextPage { get; }
}