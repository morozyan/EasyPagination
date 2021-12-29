using System.Collections.Generic;
using System.Threading.Tasks;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests;
using EasyPagination.Core.Tests.Common;
using EasyPagination.EfCore.Extensions;
using Xunit;

namespace EasyPagination.EfCore.Tests
{
    public class QueryableExtensionsTests : BaseExtensionsTests, IClassFixture<QueryableExtensionsFixture>
    {
        private readonly QueryableExtensionsFixture _fixture;

        public QueryableExtensionsTests(QueryableExtensionsFixture fixture)
        {
            _fixture = fixture;
        }
        
        protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
        {
            var task = Task.Run(() => _fixture.Context.Entities.GetPageAsync(pageOptions));
            task.Wait();
            return task.Result;
        }

        protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
        {
            var task = Task.Run(() => _fixture.Context.Entities.GetItemsAsync(pageOptions));
            task.Wait();
            return task.Result;
        }
    }
}