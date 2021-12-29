using System.Threading.Tasks;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Pagers;

namespace EasyPagination.Core.Models
{
    public class AsyncPage<T> : BasePage<T>, IAsyncPage<T>
    {
        private readonly AsyncPager<T> _pager;

        public AsyncPage(int pageCount, int itemsCount, int pageSize, AsyncPager<T> pager) : base(pageCount, itemsCount,
            pageSize)
        {
            _pager = pager;
        }

        public Task<IAsyncPage<T>> NextPageAsync() =>
            NoNextPage ? Task.FromResult<IAsyncPage<T>>(null) : _pager.GetPageAsync(GetNextPageOptions());
    }
}