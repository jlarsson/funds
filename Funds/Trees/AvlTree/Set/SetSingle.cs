using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetSingle<T> : Single<T>, ISet<T>
    {
        public SetSingle(IAvlTreeModule<T> module, T value) : base(module, value)
        {
        }

        #region ISet<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
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
            return (ISet<T>) Delete(value);
        }

        #endregion
    }
}