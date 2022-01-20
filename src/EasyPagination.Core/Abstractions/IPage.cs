namespace EasyPagination.Core.Abstractions;

public interface IPage<out T> : IBasePage<T>
{
    IPage<T> NextPage();
}