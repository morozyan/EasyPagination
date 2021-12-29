using System.Collections.Generic;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Extensions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests.Common;

namespace EasyPagination.Core.Tests
{
    public class EnumerableExtensionsTests : BaseExtensionsTests
    {
        protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
        {
            return Items.GetPage(pageOptions) as BasePage<Entity>;
        }

        protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
        {
            return Items.GetItems(pageOptions);
        }
    }
}