using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Extensions;

namespace EasyPagination.Core.Models;

public class MappedPage<T, U> :  BasePage<T>, IPage<T>
{
    private readonly IPage<U> _page;
    private readonly Func<U, T> _map;

    public MappedPage(IPage<U> page, Func<U, T> map) : base(page.Settings.PageCount, page.Settings.ItemsCount, page.Settings.PageSize)
    {
        _page = page;
        _map = map;
    }
        
    public IPage<T> NextPage() => _page.NextPage().Map(_map);
}