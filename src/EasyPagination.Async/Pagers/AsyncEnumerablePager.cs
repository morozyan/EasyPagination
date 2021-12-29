using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;
using EasyPagination.Core.Pagers;

namespace EasyPagination.Async.Pagers
{
    public class AsyncEnumerablePager<T> : AsyncPager<T>
    {
        private readonly IAsyncEnumerable<T> _enumerable;
        
        public AsyncEnumerablePager(IAsyncEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
        }

        protected override async Task<int> GetItemsCountAsync(CancellationToken cancellationToken = default)
            => await _enumerable.CountAsync(cancellationToken);

        protected override async Task<IReadOnlyList<T>> GetItemsForPageAsync(PageOptions options, CancellationToken cancellationToken = default)
            => await _enumerable.Skip(PageOptionsHelper.CalculateSkippedCount(options))
                .Take(options.PageSize)
                .ToArrayAsync(cancellationToken);

    }
}