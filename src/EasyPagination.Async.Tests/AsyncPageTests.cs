using EasyPagination.Core.Extensions;
using Shouldly;
using Xunit;

namespace EasyPagination.Async.Tests;

public class AsyncPageTests
{
    private readonly ICollection<Entity> _items;

    public AsyncPageTests()
    {
        _items = EntityGenerator.Create(2500);
    }

    [Fact]
    public async Task Should_provide_next_page_when_it_is_available()
    {
        var pageOptions = new PageOptions
        {
            PageSize = 100
        };

        var firstPage = await _items.ToAsyncEnumerable().GetPageAsync(pageOptions);
        var secondPage = await firstPage.NextPageAsync();

        secondPage.Items.Count.ShouldBe(100);
        secondPage.Items.ShouldAllBe(i => 101 <= i.Id && i.Id <= 200);
        secondPage.Settings.CurrentPage.ShouldBe(2);
        secondPage.Settings.PageSize.ShouldBe(firstPage.Settings.PageSize);
        secondPage.Settings.PageSize.ShouldBe(100);
    }

    [Fact]
    public async Task Should_provide_null_for_next_page_when_current_page_is_last()
    {
        var pageOptions = new PageOptions
        {
            Page = 3
        };

        var page = await _items.ToAsyncEnumerable().GetPageAsync(pageOptions);

        var nextPage = await page.NextPageAsync();

        nextPage.ShouldBeNull();
    }

    [Fact]
    public async Task Should_map_page()
    {
        var page = await _items.ToAsyncEnumerable().GetPageAsync(new PageOptions());

        var mappedPage = page.Map(o => o.Id);

        mappedPage.Items.First().ShouldBe(1);
    }

    [Fact]
    public async Task Should_provide_next_page_when_current_page_is_mapped()
    {
        var page = await _items.ToAsyncEnumerable().GetPageAsync(new PageOptions());

        var mappedPage = page.Map(o => o.Id);

        var nextPage = await mappedPage.NextPageAsync();

        nextPage.Items.First().ShouldBe(1001);
    }

    [Fact]
    public async Task Should_map_page_when_current_page_is_mapped()
    {
        var page = await _items.ToAsyncEnumerable().GetPageAsync(new PageOptions());

        var mappedPage = page.Map(o => o.Id);

        var newMappedPage = mappedPage.Map(o => -o);

        newMappedPage.Items.First().ShouldBe(-1);
    }
        
    [Fact]
    public async Task Should_map_wrong_page_without_errors()
    {
        var page = await _items.ToAsyncEnumerable().GetPageAsync(new PageOptions
        {
            Page = 6
        });
            
        var mappedPage = page.Map(o => o.Id);
            
        mappedPage.Items.Count.ShouldBe(0);
        mappedPage.Settings.CurrentPage.ShouldBeNull();
    }
}