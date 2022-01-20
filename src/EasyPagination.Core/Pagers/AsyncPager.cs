using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;

namespace EasyPagination.Core.Pagers;

public abstract class AsyncPager<T>
{
    public async Task<IAsyncPage<T>> GetPageAsync(PageOptions options, CancellationToken cancellationToken = default)
    {
        if (options == null)
        {
            return null;
        }
            
        var itemsCount = await GetItemsCountAsync(cancellationToken);

        var page = Create(options, itemsCount);

        if (PageOptionsHelper.IsPageNumberIncorrect(page, options))
        {
            return page;
        }

        var items = await GetItemsForPageAsync(options, cancellationToken);

        page.AddItems(options, items);
        return page;
    }

    public Task<IReadOnlyList<T>> GetItemsAsync(PageOptions options,
        CancellationToken cancellationToken = default)
        => PageOptionsHelper.IsNonPositivePage(options)
            ? Task.FromResult<IReadOnlyList<T>>(Enumerable.Empty<T>().ToList())
            : GetItemsForPageAsync(options, cancellationToken);
        
    protected abstract Task<IReadOnlyList<T>> GetItemsForPageAsync(PageOptions options,
        CancellationToken cancellationToken = default);

    protected abstract Task<int> GetItemsCountAsync(CancellationToken cancellationToken = default);
        
    private AsyncPage<T> Create(PageOptions options, int itemsCount)
    {
        var pageCount = PageOptionsHelper.CalculatePageCount(options, itemsCount);
        return new AsyncPage<T>(pageCount, itemsCount, options.PageSize, this);
    }
}