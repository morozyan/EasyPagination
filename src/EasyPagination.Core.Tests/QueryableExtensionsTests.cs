using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Extensions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests.Common;

namespace EasyPagination.Core.Tests
{
    public class QueryableExtensionsTests : BaseExtensionsTests
    {
        protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
        {
            return Items.AsQueryable().GetPage(pageOptions) as BasePage<Entity>;
        }

        protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
        {
            return Items.AsQueryable().GetItems(pageOptions);
        }
    }
}