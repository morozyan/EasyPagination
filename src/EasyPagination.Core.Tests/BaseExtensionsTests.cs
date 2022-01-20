using System.Collections.Generic;
using EasyPagination.Core.Abstractions;
using EasyPagination.Core.Models;
using EasyPagination.Core.Tests.Common;
using Shouldly;
using Xunit;

namespace EasyPagination.Core.Tests;

public abstract class BaseExtensionsTests
{
    protected readonly ICollection<Entity> Items;

    protected BaseExtensionsTests()
    {
        Items = EntityGenerator.Create(2500);
    }
        
    protected abstract IBasePage<Entity> GetPage(PageOptions pageOptions);
        
    protected abstract IReadOnlyList<Entity> GetItems(PageOptions pageOptions);
        
    [Fact]
    public void No_data_when_non_positive_page_is_requested()
    {
        var pageOptions = new PageOptions
        {
            Page = 0
        };

        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(0);
        page.Settings.CurrentPage.ShouldBeNull();
    }
        
    [Fact]
    public void No_data_when_items_from_non_positive_page_is_requested()
    {
        var pageOptions = new PageOptions
        {
            Page = 0
        };

        var items = GetItems(pageOptions);

        items.Count.ShouldBe(0);
    }
        
    [Fact]
    public void No_data_when_wrong_page_is_requested()
    {
        var pageOptions = new PageOptions
        {
            Page = 4
        };

        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(0);
        page.Settings.CurrentPage.ShouldBeNull();
    }
        
    [Fact]
    public void No_data_when_items_from_wrong_page_is_requested()
    {
        var pageOptions = new PageOptions
        {
            Page = 4
        };

        var items = GetItems(pageOptions);

        items.Count.ShouldBe(0);
    }

    [Fact]
    public void Provides_first_page_data_when_default_page_options_is_used()
    {
        var pageOptions = new PageOptions();
            
        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(1000);
        page.Items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 1000);
        page.Settings.CurrentPage.ShouldBe(1);
        page.Settings.ItemsCount.ShouldBe(2500);
        page.Settings.PageCount.ShouldBe(3);
    }

    [Fact]
    public void Provides_items_from_first_page_when_default_page_options_is_used()
    {
        var pageOptions = new PageOptions();
            
        var items = GetItems(pageOptions);

        items.Count.ShouldBe(1000);
        items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 1000);
    }
        
    [Fact]
    public void Provides_last_page_data_when_it_is_smaller_than_page_size()
    {
        var pageOptions = new PageOptions
        {
            Page = 3
        };
            
        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(500);
        page.Items.ShouldAllBe(i => 2000 <= i.Id && i.Id <= 2500);
        page.Settings.CurrentPage.ShouldBe(3);
    }
        
    [Fact]
    public void Provides_items_from_last_page_when_it_is_smaller_than_page_size()
    {
        var pageOptions = new PageOptions
        {
            Page = 3
        };
            
        var items = GetItems(pageOptions);

        items.Count.ShouldBe(500);
        items.ShouldAllBe(i => 2000 <= i.Id && i.Id <= 2500);
    }

    [Fact]
    public void Provides_page_data_when_page_size_is_overriden()
    {
        var pageOptions = new PageOptions
        {
            PageSize = 2
        };
            
        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(2);
        page.Items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 2);
    }
        
    [Fact]
    public void Provides_items_from_page_when_page_size_is_overriden()
    {
        var pageOptions = new PageOptions
        {
            PageSize = 2
        };
            
        var items = GetItems(pageOptions);

        items.Count.ShouldBe(2);
        items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 2);
    }
        
    [Fact]
    public void Provides_particular_page_data_when_it_is_passed_into_page_options()
    {
        var pageOptions = new PageOptions
        {
            Page = 2
        };
            
        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(1000);
        page.Items.ShouldAllBe(i => 1001 <= i.Id && i.Id <= 2000);
        page.Settings.CurrentPage.ShouldBe(2);
    }
        
    [Fact]
    public void Provides_items_from_particular_page_when_it_is_passed_into_page_options()
    {
        var pageOptions = new PageOptions
        {
            Page = 2
        };
            
        var items = GetItems(pageOptions);

        items.Count.ShouldBe(1000);
        items.ShouldAllBe(i => 1001 <= i.Id && i.Id <= 2000);
    }
        
    [Fact]
    public void Provides_first_page_data_when_null_options_is_passed()
    {
        PageOptions pageOptions = null;

        var page = GetPage(pageOptions);

        page.Items.Count.ShouldBe(1000);
        page.Items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 1000);
        page.Settings.CurrentPage.ShouldBe(1);
        page.Settings.ItemsCount.ShouldBe(2500);
        page.Settings.PageCount.ShouldBe(3);
    }  
        
    [Fact]
    public void Provides_items_from_first_page_when_null_options_for_items_is_passed()
    {
        PageOptions pageOptions = null;

        var items = GetItems(pageOptions);

        items.Count.ShouldBe(1000);
        items.ShouldAllBe(i => 1 <= i.Id && i.Id <= 1000);
    }
}