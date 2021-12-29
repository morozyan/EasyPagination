namespace EasyPagination.Core.Models
{
    public class PageOptions
    {
        private const int DefaultPageSize = 1000;
        private const int DefaultPage = 1;
        
        public int PageSize { get; set; } = DefaultPageSize;
        public int Page { get; set; } = DefaultPage;
    }
}