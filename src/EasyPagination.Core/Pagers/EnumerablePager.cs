using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;

namespace EasyPagination.Core.Pagers
{
    public class EnumerablePager<T> : Pager<T>
    {
        private readonly IEnumerable<T> _enumerable;
        public EnumerablePager(IEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
        }

        protected override int GetItemsCount() 
            => _enumerable.Count();

        protected override IReadOnlyList<T> GetItemsForPage(PageOptions options)
            => _enumerable.Skip(PageOptionsHelper.CalculateSkippedCount(options))
                .Take(options.PageSize)
                .ToArray();
    }
}