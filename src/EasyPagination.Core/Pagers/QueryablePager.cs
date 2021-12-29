using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;

namespace EasyPagination.Core.Pagers
{
    public class QueryablePager<T> : Pager<T>
    {
        private readonly IQueryable<T> _queryable;
        public QueryablePager(IQueryable<T> queryable)
        {
            _queryable = queryable;
        }

        protected override int GetItemsCount() 
            => _queryable.Count();

        protected override IReadOnlyList<T> GetItemsForPage(PageOptions options)
            => _queryable.Skip(PageOptionsHelper.CalculateSkippedCount(options))
                .Take(options.PageSize)
                .ToArray();
    }
}