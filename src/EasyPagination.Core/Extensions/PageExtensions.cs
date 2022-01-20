using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;

namespace EasyPagination.Core.Extensions;

public static class PageExtensions
{
    public static IPage<U> Map<T, U>(this IPage<T> page, Func<T, U> map)
    {
        var newPage = new MappedPage<U, T>(page, map);
        newPage.MapItems(map, page);
        return newPage;
    }
        
    public static IAsyncPage<U> Map<T, U>(this IAsyncPage<T> page, Func<T, U> map)
    {
        var newPage = new AsyncMappedPage<U, T>(page, map);
        newPage.MapItems(map, page);
        return newPage;
    }
}