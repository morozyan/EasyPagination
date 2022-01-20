using System.Collections.Generic;
using System.Linq;

namespace EasyPagination.Core.Tests.Common;

public static class EntityGenerator
{
    public static ICollection<Entity> Create(int count) =>
        Enumerable.Range(1, count).Select(id => new Entity { Id = id }).ToArray();
}