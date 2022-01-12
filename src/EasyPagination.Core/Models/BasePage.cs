using System;
using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Abstractions;

namespace EasyPagination.Core.Models
{
    public abstract class BasePage<T> : IBasePage<T>
    {
        protected BasePage(int pageCount, int itemsCount, int pageSize)
        {
            Items = Array.Empty<T>();
            Settings = new PageSettings
            {
                PageCount = pageCount,
                ItemsCount = itemsCount,
                PageSize = pageSize
            };
        }

        public IReadOnlyList<T> Items { get; private set; }
        public IPageSettings Settings { get; }

        protected PageOptions GetNextPageOptions() => CreatePageOptions(this, 1);

        public bool HasNextPage => !(!Settings.CurrentPage.HasValue || Settings.CurrentPage == Settings.PageCount);

        public void AddItems(PageOptions options, IReadOnlyList<T> items)
        {
            Items = items;
            Settings.CurrentPage = options.Page;
        }

        public void MapItems<U>(Func<U, T> map, IBasePage<U> newPage)
        {
            var pageOptions = CreatePageOptions(newPage);

            if (pageOptions == null)
            {
                return;
            }

            AddItems(pageOptions, newPage.Items.Select(map).ToArray());
        }

        private static PageOptions CreatePageOptions<U>(IBasePage<U> page, int offset = 0)
        {
            return page.Settings.CurrentPage.HasValue
                ? new PageOptions
                {
                    Page = page.Settings.CurrentPage.Value + offset,
                    PageSize = page.Settings.PageSize
                }
                : null;
        }
    }
}