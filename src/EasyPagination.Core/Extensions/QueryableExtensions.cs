using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Pagers;

namespace EasyPagination.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IPage<T> GetPage<T>(this IQueryable<T> queryable, PageOptions options)
            => new QueryablePager<T>(queryable).GetPage(options);

        public static IReadOnlyList<T> GetItems<T>(this IQueryable<T> queryable, PageOptions options)
            => new QueryablePager<T>(queryable).GetItems(options);
    }
}