using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Set
{
    public class SetModule<T>: IAvlTreeModule<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly SetEmpty<T> _empty;

        public SetModule() : this(Comparer<T>.Default)
        {
        }

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
            if (left.IsEmpty && right.IsEmpty)
            {
                return new SetSingle<T>(this, value);
            }
            return new SetNode<T>(this, left, value, right);
        }

        public int Compare(T a, T b)
        {
            return _comparer.Compare(a, b);
        }

        #endregion
    }
}