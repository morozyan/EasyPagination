using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Helpers;
using EasyPagination.Core.Models;

namespace EasyPagination.Core.Pagers;

public abstract class Pager<T>
{
    public IPage<T> GetPage(PageOptions options)
    {
        if (options == null)
        {
            return null;
        }
            
        var itemsCount = GetItemsCount();

        var page = Create(options, itemsCount);

        if (PageOptionsHelper.IsPageNumberIncorrect(page, options))
        {
            return page;
        }

        var items = GetItemsForPage(options);

        page.AddItems(options, items);
        return page;
    }

    public IReadOnlyList<T> GetItems(PageOptions options) 
        => PageOptionsHelper.IsNonPositivePage(options)
            ? Enumerable.Empty<T>().ToList()
            : GetItemsForPage(options);
        
    protected abstract IReadOnlyList<T> GetItemsForPage(PageOptions options);

    protected abstract int GetItemsCount();
        
    private Page<T> Create(PageOptions options, int itemsCount)
    {
        var pageCount = PageOptionsHelper.CalculatePageCount(options, itemsCount);
        return new Page<T>(pageCount, itemsCount, options.PageSize, this);
    }
}