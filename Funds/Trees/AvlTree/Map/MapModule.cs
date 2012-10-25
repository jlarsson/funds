using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Map
{
    public class MapModule<TKey, TValue> : IAvlTreeModule<KeyValuePair<TKey, TValue>>
    {
        public static readonly MapModule<TKey, TValue> Default = new MapModule<TKey, TValue>(Comparer<TKey>.Default);
        private readonly IComparer<TKey> _comparer;
        private readonly IAvlNode<KeyValuePair<TKey, TValue>> _empty;

        public MapModule(IComparer<TKey> comparer)
        {
            _comparer = comparer;
            _empty = new MapEmpty<TKey, TValue>(this);
        }

        #region IAvlTreeModule<KeyValuePair<TKey,TValue>> Members

        public IAvlNode<KeyValuePair<TKey, TValue>> Empty
        {
            get { return _empty; }
        }

        public IAvlNode<KeyValuePair<TKey, TValue>> CreateSingle(KeyValuePair<TKey, TValue> value)
        {
            return new MapSingle<TKey, TValue>(this, value);
        }

        public IAvlNode<KeyValuePair<TKey, TValue>> CreateNode(IAvlNode<KeyValuePair<TKey, TValue>> left,
                                                               KeyValuePair<TKey, TValue> value,
                                                               IAvlNode<KeyValuePair<TKey, TValue>> right)
        {
            return left.IsEmpty && right.IsEmpty
                       ? (IAvlNode<KeyValuePair<TKey, TValue>>) new MapSingle<TKey, TValue>(this, value)
                       : new MapNode<TKey, TValue>(this, left, value, right);
        }

        public int Compare(KeyValuePair<TKey, TValue> a, KeyValuePair<TKey, TValue> b)
        {
            return _comparer.Compare(a.Key, b.Key);
        }

        #endregion
    }
}