using EasyPagination.Core.Abstractions;

namespace EasyPagination.Core.Models
{
    public class PageSettings : IPageSettings
    {
        public int? CurrentPage { get; set; }

        public int PageCount { get; set; }
        public int ItemsCount { get; set; }
        public int PageSize { get; set; }
    }
}