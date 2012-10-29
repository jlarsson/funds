using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeMap
{
    public abstract class AbstractTreeMapColorNode<TKey, TValue> : AbstractColorNode<KeyValuePair<TKey, TValue>>,
                                                                   IMap<TKey, TValue>
    {
        private readonly ITreeModule<KeyValuePair<TKey, TValue>> _module;

        protected AbstractTreeMapColorNode(ITreeModule<KeyValuePair<TKey, TValue>> module,
                                           INode<KeyValuePair<TKey, TValue>> left, KeyValuePair<TKey, TValue> value,
                                           INode<KeyValuePair<TKey, TValue>> right) : base(left, value, right)
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
            return Find(new KeyValuePair<TKey, TValue>(key, default(TValue))) != null;
        }

        public TValue TryGetValue(TKey key, TValue defaultValue = default(TValue))
        {
            var n = Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
            return n == null ? defaultValue : n.GetValue().Value;
        }

        public IMap<TKey, TValue> Add(TKey key, TValue value)
        {
            return (IMap<TKey, TValue>) Insert(new KeyValuePair<TKey, TValue>(key, value));
        }

        public IMap<TKey, TValue> Remove(TKey key)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Enumerate().Select(n => n.GetValue()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}