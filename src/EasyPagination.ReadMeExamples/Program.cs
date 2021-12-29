using System.Collections.Generic;
using System.Globalization;
using EasyPagination.EfCore.Tests.Common;
using EasyPagination.Core.Tests.Common;

using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Extensions;
using EasyPagination.Core.Models;
using EasyPagination.EfCore.Extensions;

EntityDbContext context = CreateContext();


IPage<Entity> firstPage = context.Entities.GetPage(new PageOptions
{
    PageSize = 10
});

DoSomeWork(firstPage.Items, firstPage.Settings.PageCount, firstPage.Settings.CurrentPage, firstPage.Settings.PageSize);

IReadOnlyList<Entity> firstPageItems = context.Entities.GetItems(new PageOptions
{
    PageSize = 10
});

var page = firstPage;

while (page != null)
{
    DoSomeWork(page.Items, page.Settings.PageCount, page.Settings.CurrentPage, page.Settings.PageSize);
    page = page.NextPage();
}

IAsyncPage<Entity> pageForInMemoryMapping = await context.Entities
    .GetPageAsync(new PageOptions());

IAsyncPage<string> formattedDataPage = pageForInMemoryMapping
    .Map(o => $"{o.Id} {o.CreatedDate:dd/MM/yyyy hh:mm}");

DoSomeWork(formattedDataPage.Items, formattedDataPage.Settings.PageCount, formattedDataPage.Settings.CurrentPage, formattedDataPage.Settings.PageSize);

void DoSomeWork<T>(IReadOnlyList<T> readOnlyList, int settingsPageCount, int? currentPage, int settingsPageSize)
{
    
}

EntityDbContext CreateContext()
{
    return null;
}