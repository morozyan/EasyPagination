namespace EasyPagination.Core.Models
{
    public class PageOptions
    {
        private const int DefaultPageSize = 1000;
        private const int DefaultPage = 1;

        public PageOptions(int page = DefaultPage, int pageSize = DefaultPageSize)
        {
            PageSize = pageSize;
            Page = page;
        }

        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}