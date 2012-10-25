using System.Collections;
using System.Collections.Generic;
using Funds.Trees.AvlTree.Set;

namespace Funds
{
    public static class Set
    {
        public static ISet<T> Empty<T>()
        {
            return (ISet<T>) SetModule<T>.Default.Empty;
        }

        public static ISet<T> Empty<T>(IComparer<T> comparer)
        {
            return (ISet<T>) new SetModule<T>(comparer).Empty;
        }
    }

    public class Set<T>: ISet<T>
    {
        private ISet<T> _inner;

        public Set()
        {
            _inner = Set.Empty<T>();
        }
        public Set(IComparer<T> comparer)
        {
            _inner = Set.Empty<T>();
        }

        public bool IsEmpty
        {
            get { return _inner.IsEmpty; }
        }

        public bool Contains(T value)
        {
            return _inner.Contains(value);
        }

        ISet<T> ISet<T>.Add(T value)
        {
            return _inner.Add(value);
        }

        public ISet<T> Remove(T value)
        {
            return _inner.Remove(value);
        }

        public void Add(T value)
        {
            _inner = _inner.Add(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }
    }
}