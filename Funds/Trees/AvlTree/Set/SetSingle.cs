using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetSingle<T>: Single<T>, ISet<T>
    {
        public SetSingle(IAvlTreeModule<T> module, T value) : base(module, value)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            return false;

        }

        public ISet<T> Add(T value)
        {
            return (ISet<T>) Insert(value);
        }
    }
}