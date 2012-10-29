using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Funds.Trees.AvlTree.Map
{
    public class MapNode<TKey, TValue> : Node<KeyValuePair<TKey, TValue>>, IMap<TKey, TValue>
    {
        public MapNode(IAvlTreeModule<KeyValuePair<TKey, TValue>> module, IAvlNode<KeyValuePair<TKey, TValue>> left,
                       KeyValuePair<TKey, TValue> value, IAvlNode<KeyValuePair<TKey, TValue>> right)
            : base(module, left, value, right)
        {
        }

        #region IMap<TKey,TValue> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return (Enumerate().Select(n => n.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Enumerate().Select(n => n.Value)).GetEnumerator();
        }

        public bool ContainsKey(TKey key)
        {
            return !Find(new KeyValuePair<TKey, TValue>(key, default(TValue))).IsEmpty;
        }

        public TValue TryGetValue(TKey key, TValue defaultValue = default(TValue))
        {
            var n = Find(new KeyValuePair<TKey, TValue>(key, default(TValue)));
            return n.IsEmpty ? defaultValue : n.Value.Value;
        }

        public IMap<TKey, TValue> Add(TKey key, TValue value)
        {
            return (IMap<TKey, TValue>) Update(new KeyValuePair<TKey, TValue>(key, value));
        }

        public IMap<TKey, TValue> Remove(TKey key)
        {
            return (IMap<TKey, TValue>) Delete(new KeyValuePair<TKey, TValue>(key, default(TValue)));
        }

        #endregion
    }
}