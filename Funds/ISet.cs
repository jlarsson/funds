using System.Collections.Generic;

namespace Funds
{
    public interface ISet<T>: IEnumerable<T>
    {
        bool IsEmpty { get; }
        bool Contains(T value);
        ISet<T> Add(T value);
        ISet<T> Remove(T value);
    }
}