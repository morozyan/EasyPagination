using System.Collections.Generic;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests.Common;
using Shouldly;
using Xunit;

namespace EasyPagination.Core.Tests
{
    public abstract class BasePagerTests
    {
        protected readonly ICollection<Entity> Items;

        protected BasePagerTests()
        {
            Items = EntityGenerator.Create(2500);
        }
        
        protected abstract IBasePage<Entity> GetPage(PageOptions pageOptions);
        
        protected abstract IReadOnlyList<Entity> GetItems(PageOptions pageOptions);
        
        [Fact]
        public void Returns_null_when_null_options_is_passed()
        {
            PageOptions pageOptions = null;

            var firstPage = GetPage(pageOptions);

            firstPage.ShouldBeNull();
        }
        [Fact]
        public void Returns_null_when_null_options_for_items_is_passed()
        {            
            PageOptions pageOptions = null;

            var items = GetItems(pageOptions);

            items.Count.ShouldBe(0);
        }
    }
}