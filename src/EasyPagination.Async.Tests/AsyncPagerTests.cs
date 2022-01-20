namespace EasyPagination.Async.Tests;

public class AsyncPagerTests : BasePagerTests
{
    protected override IBasePage<Entity> GetPage(PageOptions pageOptions)
    {
        var task = Task.Run(() => new AsyncEnumerablePager<Entity>(Items.ToAsyncEnumerable()).GetPageAsync(pageOptions));
        task.Wait();
        return task.Result;
    }

    protected override IReadOnlyList<Entity> GetItems(PageOptions pageOptions)
    {
        var task = Task.Run(() => new AsyncEnumerablePager<Entity>(Items.ToAsyncEnumerable()).GetItemsAsync(pageOptions));
        task.Wait();
        return task.Result;
    }
}