using System.Collections.Generic;

namespace EasyPagination.Core.Abstractions
{
    public interface IBasePage<out T>
    {
        IReadOnlyList<T> Items { get; }
        IPageSettings Settings { get; }
    }
}