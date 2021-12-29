namespace EasyPagination.Core.Abstractions
{
    public interface IPage<T> : IBasePage<T>
    {
        IPage<T> NextPage();
    }
}