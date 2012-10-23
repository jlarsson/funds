using System.Collections.Generic;

namespace Funds
{
    public interface ISet<T>: IEnumerable<T>
    {
        bool IsEmpty();
        bool Contains(T value);
        ISet<T> Add(T value);
    }
}