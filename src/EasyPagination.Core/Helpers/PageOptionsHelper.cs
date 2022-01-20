using EasyPagination.Core.Models;

namespace EasyPagination.Core.Helpers;

public static class PageOptionsHelper
{
    public static int CalculateSkippedCount(PageOptions options)
        => options.PageSize * (options.Page - 1);

    public static int CalculatePageCount(PageOptions options, int itemsCount)
        => itemsCount / options.PageSize + (itemsCount % options.PageSize > 0 ? 1 : 0);

    public static bool IsPageNumberIncorrect<T>(BasePage<T> page, PageOptions options) =>
        page.Settings.PageCount < options.Page || IsNonPositivePage(options);

    public static bool IsNonPositivePage(PageOptions options) =>
        options is not { Page: > 0 };
}