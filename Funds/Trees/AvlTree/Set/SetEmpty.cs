using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Funds.Trees.AvlTree.Set
{
    public class SetEmpty<T>: Empty<T>, ISet<T>
    {
        public SetEmpty(IAvlTreeModule<T> module) : base(module)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (Enumerate().Select(n => n.Value)).GetEnumerator();

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
