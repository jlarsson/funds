using System.Collections.Generic;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeMap
{
    public class TreeMapModule<TKey, TValue> : ITreeModule<KeyValuePair<TKey, TValue>>
    {
        public TreeMapModule(IComparer<TKey> comparer)
        {
            Comparer = comparer;
        }

        public IComparer<TKey> Comparer { get; protected set; }

        #region ITreeModule<KeyValuePair<TKey,TValue>> Members

        public int Compare(KeyValuePair<TKey, TValue> a, KeyValuePair<TKey, TValue> b)
        {
            return Comparer.Compare(a.Key, b.Key);
        }

        public INode<KeyValuePair<TKey, TValue>> CreateEmpty()
        {
            return new TreeMapEmptyNode<TKey, TValue>(this);
        }

        public INode<KeyValuePair<TKey, TValue>> CreateRed(INode<KeyValuePair<TKey, TValue>> left,
                                                           KeyValuePair<TKey, TValue> value,
                                                           INode<KeyValuePair<TKey, TValue>> right)
        {
            return new RedTreeMapNode<TKey, TValue>(this, left, value, right);
        }

        public INode<KeyValuePair<TKey, TValue>> CreateBlack(INode<KeyValuePair<TKey, TValue>> left,
                                                             KeyValuePair<TKey, TValue> value,
                                                             INode<KeyValuePair<TKey, TValue>> right)
        {
            return new BlackTreeMapNode<TKey, TValue>(this, left, value, right);
        }

        #endregion
    }
}