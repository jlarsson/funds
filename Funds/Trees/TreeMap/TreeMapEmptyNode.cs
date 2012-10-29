using System.Collections;
using System.Collections.Generic;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeMap
{
    public class TreeMapEmptyNode<TKey, TValue> : AbstractEmptyNode<KeyValuePair<TKey, TValue>>, IMap<TKey, TValue>
    {
        private readonly ITreeModule<KeyValuePair<TKey, TValue>> _module;

        public TreeMapEmptyNode(ITreeModule<KeyValuePair<TKey, TValue>> module)
        {
            _module = module;
        }

        public override ITreeModule<KeyValuePair<TKey, TValue>> Module
        {
            get { return _module; }
        }

        #region IMap<TKey,TValue> Members

        public bool ContainsKey(TKey key)
        {
            return false;
        }

        public TValue TryGetValue(TKey key, TValue defaultValue = default(TValue))
        {
            return defaultValue;
        }

        public IMap<TKey, TValue> Add(TKey key, TValue value)
        {
            return (IMap<TKey, TValue>) base.Insert(new KeyValuePair<TKey, TValue>(key, value));
        }

        public IMap<TKey, TValue> Remove(TKey key)
        {
            return this;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}