using System.Collections.Generic;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Pagers;
using EasyPagination.Core.Tests.Common;

namespace EasyPagination.Core.Tests;

public class PagerTests : BasePagerTests
{
    protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
    {
        return new EnumerablePager<Entity>(Items).GetPage(pageOptions) as BasePage<Entity>;
    }

    protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
    {
        return new EnumerablePager<Entity>(Items).GetItems(pageOptions);
    }
}