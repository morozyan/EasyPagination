using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyPagination.Async.Extensions;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests;
using EasyPagination.Core.Tests.Common;

namespace EasyPagination.Async.Tests
{
    public class AsyncEnumerableExtensionsTests : BaseExtensionsTests
    {
        protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
        {
            var task = Task.Run(() => Items.ToAsyncEnumerable().GetPageAsync(pageOptions));
            task.Wait();
            return task.Result;
        }

        protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
        {
            var task = Task.Run(() => Items.ToAsyncEnumerable().GetItemsAsync(pageOptions));
            task.Wait();
            return task.Result;
        }
    }
}