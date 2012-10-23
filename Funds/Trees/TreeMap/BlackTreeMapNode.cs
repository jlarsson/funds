using System.Collections.Generic;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeMap
{
    public class BlackTreeMapNode<TKey, TValue> : AbstractTreeMapColorNode<TKey, TValue>
    {
        public BlackTreeMapNode(ITreeModule<KeyValuePair<TKey, TValue>> module, INode<KeyValuePair<TKey, TValue>> left,
                                KeyValuePair<TKey, TValue> value,
                                INode<KeyValuePair<TKey, TValue>> right)
            : base(module, left, value, right)
        {
        }

        protected override NodeColor Color
        {
            get { return NodeColor.Black; }
        }
    }
}