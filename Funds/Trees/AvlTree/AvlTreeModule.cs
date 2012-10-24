using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public class AvlTreeModule<T> : IAvlTreeModule<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly Empty<T> _empty;

        public AvlTreeModule() : this(Comparer<T>.Default)
        {
        }

        public AvlTreeModule(IComparer<T> comparer)
        {
            _comparer = comparer;
            _empty = new Empty<T>(this);
        }

        #region IAvlTreeModule<T> Members

        public IAvlNode<T> Empty
        {
            get { return _empty; }
        }

        public IAvlNode<T> CreateSingle(T value)
        {
            return new Single<T>(this, value);
        }

        public IAvlNode<T> CreateNode(IAvlNode<T> left, T value, IAvlNode<T> right)
        {
            if (left.IsEmpty && right.IsEmpty)
            {
                return new Single<T>(this, value);
            }
            return new Node<T>(this, left, value, right);
        }

        public int Compare(T a, T b)
        {
            return _comparer.Compare(a, b);
        }

        #endregion
    }
}