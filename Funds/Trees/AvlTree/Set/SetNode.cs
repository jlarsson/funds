using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetNode<T> : Node<T>, ISet<T>
    {
        public SetNode(IAvlTreeModule<T> module, IAvlNode<T> left, T value, IAvlNode<T> right)
            : base(module, left, value, right)
        {
        }

        #region ISet<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return CreateEnumerator(n => n.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CreateEnumerator(n => n.Value);
        }

        public bool Contains(T value)
        {
            return !Find(value).IsEmpty;
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