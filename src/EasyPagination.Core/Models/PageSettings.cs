using EasyPagination.Core.Abstractions;

namespace EasyPagination.Core.Models;

public class PageSettings : IPageSettings
{
    int? IPageSettings.CurrentPage { get; set; }

    public int PageCount { get; init; }
    public int ItemsCount { get; init; }
    public int PageSize { get; init; }
}