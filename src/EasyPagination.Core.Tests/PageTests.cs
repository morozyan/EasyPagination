using System.Collections.Generic;
using System.Linq;
using EasyPagination.Core.Extensions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests.Common;
using Shouldly;
using Xunit;

namespace EasyPagination.Core.Tests;

public class PageTests
{
    private readonly ICollection<Entity> _items;

    public PageTests()
    {
        _items = EntityGenerator.Create(2500);
    }

    [Fact]
    public void Should_provide_next_page_when_it_is_available()
    {
        var pageOptions = new PageOptions
        {
            PageSize = 100
        };

        var firstPage = _items.GetPage(pageOptions);
        var secondPage = firstPage.NextPage();

        secondPage.Items.Count.ShouldBe(100);
        secondPage.Items.ShouldAllBe(i => 101 <= i.Id && i.Id <= 200);
        secondPage.Settings.CurrentPage.ShouldBe(2);
        secondPage.Settings.PageSize.ShouldBe(firstPage.Settings.PageSize);
        secondPage.Settings.PageSize.ShouldBe(100);
    }

    [Fact]
    public void Should_provide_null_for_next_page_when_current_page_is_last()
    {
        var pageOptions = new PageOptions
        {
            Page = 3
        };

        var page = _items.GetPage(pageOptions);

        var nextPage = page.NextPage();
            
        nextPage.ShouldBeNull();
    }

    [Fact]
    public void Should_map_page()
    {
        var page = _items.GetPage(new PageOptions()).Map(o => o.Id);
            
        page.Items.First().ShouldBe(1);
    }
        
    [Fact]
    public void Should_provide_next_page_when_current_page_is_mapped()
    {
        var page = _items.GetPage(new PageOptions()).Map(o => o.Id);
            
        var nextPage = page.NextPage();
            
        nextPage.Items.First().ShouldBe(1001);
    }
        
    [Fact]
    public void Should_map_page_when_current_page_is_mapped()
    {
        var page = _items.GetPage(new PageOptions()).Map(o => o.Id);
            
        var mappedPage = page.Map(o => -o);
            
        mappedPage.Items.First().ShouldBe(-1);
    }
        
    [Fact]
    public void Should_map_wrong_page_without_errors()
    {
        var page = _items.GetPage(new PageOptions
        {
            Page = 6
        }).Map(o => o.Id);
            
        page.Items.Count.ShouldBe(0);
        page.Settings.CurrentPage.ShouldBeNull();
    }
}