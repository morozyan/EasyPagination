using EasyPagination.Core.Abstractions;

namespace EasyPagination.Core.Models
{
     public class PageSettings : IPageSettings
     {
         int? IPageSettings.CurrentPage { get; set; }

         public int PageCount { get; set; }
        public int ItemsCount { get; set; }
        public int PageSize { get; set; }
    }
}