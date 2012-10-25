using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetEmpty<T> : Empty<T>, ISet<T>
    {
        public SetEmpty(IAvlTreeModule<T> module) : base(module)
        {
        }

        #region ISet<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }

        public bool Contains(T value)
        {
            return false;
        }

        public ISet<T> Add(T value)
        {
            return (ISet<T>) Update(value);
        }

        public ISet<T> Remove(T value)
        {
            return this;
        }

        #endregion
    }
}