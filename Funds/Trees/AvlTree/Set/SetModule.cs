using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetModule<T> : IAvlTreeModule<T>
    {
        public static readonly SetModule<T> Default = new SetModule<T>(Comparer<T>.Default);
        private readonly IComparer<T> _comparer;
        private readonly IAvlNode<T> _empty;

        public SetModule(IComparer<T> comparer)
        {
            _comparer = comparer;
            _empty = new SetEmpty<T>(this);
        }

        #region IAvlTreeModule<T> Members

        public IAvlNode<T> Empty
        {
            get { return _empty; }
        }

        public IAvlNode<T> CreateSingle(T value)
        {
            return new SetSingle<T>(this, value);
        }

        public IAvlNode<T> CreateNode(IAvlNode<T> left, T value, IAvlNode<T> right)
        {
            return left.IsEmpty && right.IsEmpty
                       ? (IAvlNode<T>) new SetSingle<T>(this, value)
                       : new SetNode<T>(this, left, value, right);
        }

        public int Compare(T a, T b)
        {
            return _comparer.Compare(a, b);
        }

        #endregion
    }
}