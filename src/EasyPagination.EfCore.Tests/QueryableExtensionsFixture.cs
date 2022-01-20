using EasyPagination.EfCore.Tests.Common;
using Microsoft.EntityFrameworkCore;

namespace EasyPagination.EfCore.Tests;

public class QueryableExtensionsFixture
{
    public EntityDbContext Context { get; }

    public QueryableExtensionsFixture()
    {
        var options = new DbContextOptionsBuilder<EntityDbContext>()
            .UseInMemoryDatabase(GetType().FullName)
            .Options;
            
        Context = new EntityDbContext(options);
        Context.AddRange(EntityGenerator.Create(2500));
        Context.SaveChanges();
    }
}