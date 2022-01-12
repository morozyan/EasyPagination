using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.EfCore.Pagers;

namespace EasyPagination.EfCore.Extensions
{
    public static class QueryableExtensions
    {
        public static Task<IAsyncPage<T>> GetPageAsync<T>(this IQueryable<T> queryable, PageOptions options = null)
            => new QueryablePager<T>(queryable).GetPageAsync(options ?? new PageOptions());

        public static Task<IReadOnlyList<T>> GetItemsAsync<T>(this IQueryable<T> queryable, PageOptions options = null)
            => new QueryablePager<T>(queryable).GetItemsAsync(options ?? new PageOptions());
    }
}