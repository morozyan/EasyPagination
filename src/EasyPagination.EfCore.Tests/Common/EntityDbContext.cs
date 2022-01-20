using Microsoft.EntityFrameworkCore;

namespace EasyPagination.EfCore.Tests.Common;

public class EntityDbContext : DbContext
{
    public EntityDbContext(DbContextOptions options): base(options){}
    public DbSet<Entity> Entities { get; set; }
}