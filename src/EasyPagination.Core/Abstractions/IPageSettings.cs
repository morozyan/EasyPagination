namespace EasyPagination.Core.Abstractions
{
    public interface IPageSettings
    {
        int? CurrentPage { get; internal set; }
        int PageCount { get; }
        int ItemsCount { get; }
        int PageSize { get; }
    }
}