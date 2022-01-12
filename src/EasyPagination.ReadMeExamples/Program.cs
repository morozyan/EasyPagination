using System;
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
    PageSize = 10,
    Page = 1
});

DoSomeWork(firstPage.Items);

IReadOnlyList<Entity> firstPageItems = context.Entities.GetItems(new PageOptions
{
    PageSize = 10
});

var page = firstPage;

while (page.HasNextPage)
{
    page = page.NextPage();
    DoSomeWork(page.Items);
}

IAsyncPage<Entity> pageForInMemoryMapping = await context.Entities
    .GetPageAsync(new PageOptions());

IAsyncPage<string> formattedDataPage = pageForInMemoryMapping
    .Map(o => $"{o.Id} {o.CreatedDate:dd/MM/yyyy hh:mm}");

DoSomeWork(formattedDataPage.Items);

firstPage = context.Entities.GetPage(new PageOptions(1, 1000));
firstPage = context.Entities.GetPage(new PageOptions());
firstPage = context.Entities.GetPage(null);
firstPage = context.Entities.GetPage();

IPage<Entity> wrongPage = context.Entities.GetPage(new PageOptions
{
    Page = 0
});

Console.WriteLine(wrongPage.Settings.CurrentPage.HasValue); // False
Console.WriteLine(wrongPage.Items.Count); // 0
Console.WriteLine(wrongPage.HasNextPage); // False
Console.WriteLine(wrongPage.NextPage() == null); // True

void DoSomeWork<T>(IReadOnlyList<T> readOnlyList)
{
    
}

EntityDbContext CreateContext()
{
    return null;
}