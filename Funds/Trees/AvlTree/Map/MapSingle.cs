using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Map
{
    public class MapSingle<TKey, TValue> : Single<KeyValuePair<TKey, TValue>>, IMap<TKey, TValue>
    {
        public MapSingle(IAvlTreeModule<KeyValuePair<TKey, TValue>> module, KeyValuePair<TKey, TValue> value)
            : base(module, value)
        {
        }

        #region IMap<TKey,TValue> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return Value;
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
            return (IMap<TKey, TValue>) Insert(new KeyValuePair<TKey, TValue>(key, value));
        }

        #endregion

        public IMap<TKey, TValue> Remove(TKey key)
        {
            return (IMap<TKey, TValue>) Delete(new KeyValuePair<TKey, TValue>(key, default(TValue)));
        }
    }
}