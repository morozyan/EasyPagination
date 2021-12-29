using System;
using System.Threading.Tasks;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Extensions;

namespace EasyPagination.Core.Models
{
    public class AsyncMappedPage<T, U> :  BasePage<T>, IAsyncPage<T>
    {
        private readonly IAsyncPage<U> _page;
        private readonly Func<U, T> _map;

        public AsyncMappedPage(IAsyncPage<U> page, Func<U, T> map) : base(page.Settings.PageCount, page.Settings.ItemsCount, page.Settings.PageSize)
        {
            _page = page;
            _map = map;
        }
        
        public async Task<IAsyncPage<T>> NextPageAsync()
        { 
            var nextPage = await _page.NextPageAsync();
             
            return nextPage.Map(_map);
        }
    }
}