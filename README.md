## EasyPagination
EasyPagination is a .NET library for providing paging functionality on IEnumerable/IQueryable collections.

### Installation
Package Manager Console
```bash
Install-Package EasyPagination.Core
Install-Package EasyPagination.EfCore
Install-Package EasyPagination.Async
```

.Net CLI

```bash
dotnet add package EasyPagination.Core
dotnet add package EasyPagination.EfCore
dotnet add package EasyPagination.Async
```

### Usage
Use extension method `GetPage` for accessing to particular page:
```c#
using EasyPagination.Core.Extensions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Abstractions;

public class EntityDbContext : DbContext
{
    public EntityDbContext(DbContextOptions options): base(options){}
    public DbSet<Entity> Entities { get; set; }
}

public class Entity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
    
EntityDbContext context = CreateContext();


IPage<Entity> firstPage = context.Entities.GetPage(new PageOptions()
{
    PageSize = 10,
    Page = 1
});

DoSomeWork(firstPage.Items);
```

Or use `GetItems` method if you don't need page info:
```c#
IReadOnlyList<Entity> firstPageItems = context.Entities.GetItems(new PageOptions()
{
    PageSize = 10
});
```

Next pages could be requested easily:
```c#
var page = firstPage;

while (page.HasNextPage)
{
    page = page.NextPage();
    DoSomeWork(page.Items);
}
```

Async methods for EF Core (or IAsyncEnumerable) are also available:
```c#
using EasyPagination.EfCore.Extensions; // or EasyPagination.Async.Extensions for IAsyncEnumerable 

IAsyncPage<Entity> pageForInMemoryMapping = await context.Entities
    .GetPageAsync(new PageOptions());
```
In case of complex mapping, which is not supported by EF core, 
page could be transformed into more useful form without loosing page settings:
```c#
IAsyncPage<string> formattedDataPage = pageForInMemoryMapping
    .Map(o => $"{o.Id} {o.CreatedDate:dd/MM/yyyy hh:mm}");
    
DoSomeWork(formattedDataPage.Items);
```

The calls below are equivalent. `GetItems`, `GetPageAsync`, `GetItemsAsync` provide the same behavior.
```c#

firstPage = context.Entities.GetPage(new PageOptions(1, 1000));
firstPage = context.Entities.GetPage(new PageOptions());
firstPage = context.Entities.GetPage(null);
firstPage = context.Entities.GetPage();
```
If the requested page number is non-positive or too big, page without items will be provided:
```c#
IPage<Entity> wrongPage = context.Entities.GetPage(new PageOptions
{
    Page = 0
});

Console.WriteLine(wrongPage.Settings.CurrentPage.HasValue); // False
Console.WriteLine(wrongPage.Items.Count); // 0
Console.WriteLine(wrongPage.HasNextPage); // False
Console.WriteLine(wrongPage.NextPage() == null); // True

```
