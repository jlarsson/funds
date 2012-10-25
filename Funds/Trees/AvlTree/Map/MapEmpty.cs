using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree.Map
{
    public class MapEmpty<TKey, TValue> : Empty<KeyValuePair<TKey, TValue>>, IMap<TKey, TValue>
    {
        public MapEmpty(IAvlTreeModule<KeyValuePair<TKey, TValue>> module) : base(module)
        {
        }

        #region IMap<TKey,TValue> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }

        public bool ContainsKey(TKey value)
        {
            return false;
        }

        public TValue TryGetValue(TKey key, TValue defaultValue = default(TValue))
        {
            return defaultValue;
        }

        public IMap<TKey, TValue> Add(TKey key, TValue value)
        {
            return (IMap<TKey, TValue>) Insert(new KeyValuePair<TKey, TValue>(key, value));
        }

        #endregion

        public IMap<TKey, TValue> Remove(TKey key)
        {
            return this;
        }
    }
}