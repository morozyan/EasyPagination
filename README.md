## EasyPagination
EasyPagination is a .NET library for providing paging functionality on IEnumerable/IQueryable collections.

### Installation
Package Manager Console
```bash
Install-Package 
```

.Net CLI

```bash
dotnet add package 
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
    PageSize = 10
});

DoSomeWork(firstPage.Items, firstPage.Settings.PageCount, firstPage.Settings.CurrentPage, firstPage.Settings.PageSize);
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

while (page != null)
{
    DoSomeWork(page.Items, page.Settings.PageCount, page.Settings.CurrentPage, page.Settings.PageSize);
    
    page = page.NextPage();
}
```

Async methods for EF Core (or IAsyncEnumerable) are also available:
```c#
using EasyPagination.EfCore.Extensions;

IAsyncPage<Entity> pageForInMemoryMapping = await context.Entities
    .GetPageAsync(new PageOptions());
```
In case of complex mapping, which is not supported by EF core, 
page could be transformed into more useful form without loosing page settings:
```c#
IAsyncPage<string> formattedDataPage = pageForInMemoryMapping
    .Map(o => $"{o.Id} {o.CreatedDate:dd/MM/yyyy hh:mm}");
    
DoSomeWork(formattedDataPage.Items, formattedDataPage.Settings.PageCount, formattedDataPage.Settings.CurrentPage, formattedDataPage.Settings.PageSize);
```

