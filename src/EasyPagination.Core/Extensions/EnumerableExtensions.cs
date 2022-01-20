using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Pagers;

namespace EasyPagination.Core.Extensions;

public static class EnumerableExtensions
{
    public static IPage<T> GetPage<T>(this IEnumerable<T> enumerable, PageOptions options = null) 
        => new EnumerablePager<T>(enumerable).GetPage(options ?? new PageOptions());

    public static IReadOnlyList<T> GetItems<T>(this IEnumerable<T> enumerable, PageOptions options = null) 
        => new EnumerablePager<T>(enumerable).GetItems(options ?? new PageOptions());
}