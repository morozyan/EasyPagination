using EasyPagination.Async.Pagers;
using EasyPagination.Core.Abstractions;

namespace EasyPagination.Async.Extensions;

public static class AsyncEnumerableExtensions
{
    public static Task<IAsyncPage<T>> GetPageAsync<T>(this IAsyncEnumerable<T> asyncEnumerable, PageOptions options = null)
        => new AsyncEnumerablePager<T>(asyncEnumerable).GetPageAsync(options ?? new PageOptions());

    public static Task<IReadOnlyList<T>> GetItemsAsync<T>(this IAsyncEnumerable<T> asyncEnumerable, PageOptions options = null)
        => new AsyncEnumerablePager<T>(asyncEnumerable).GetItemsAsync(options ?? new PageOptions());
}