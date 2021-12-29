using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;
using EasyPagination.Core.Pagers;
using Microsoft.EntityFrameworkCore;

namespace EasyPagination.EfCore.Pagers
{
    public class QueryablePager<T> : AsyncPager<T>
    {
        private readonly IQueryable<T> _queryable;
        public QueryablePager(IQueryable<T> queryable)
        {
            _queryable = queryable;
        }

        protected override Task<int> GetItemsCountAsync(CancellationToken cancellationToken = default) 
            =>  _queryable.CountAsync(cancellationToken);

        protected override async Task<IReadOnlyList<T>> GetItemsForPageAsync(PageOptions options, CancellationToken cancellationToken = default)
            => await _queryable.Skip(PageOptionsHelper.CalculateSkippedCount(options))
                .Take(options.PageSize)
                .ToListAsync(cancellationToken);
    }
}