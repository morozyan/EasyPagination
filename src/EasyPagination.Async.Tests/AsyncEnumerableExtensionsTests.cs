namespace EasyPagination.Async.Tests;

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