using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Pagers;

namespace EasyPagination.Core.Models;

public class Page<T> : BasePage<T>, IPage<T>
{
    private readonly Pager<T> _pager;

    public Page(int pageCount, int itemsCount, int pageSize, Pager<T> pager) 
        : base(pageCount, itemsCount, pageSize)
    {
        _pager = pager;
    }

    public IPage<T> NextPage() => HasNextPage ? _pager.GetPage(GetNextPageOptions()) : null;
        
}