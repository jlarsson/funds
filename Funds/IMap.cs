using System.Collections.Generic;

namespace Funds
{
    public interface IMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        bool IsEmpty { get; }
        bool ContainsKey(TKey key);
        TValue TryGetValue(TKey key, TValue defaultValue = default (TValue));
        IMap<TKey, TValue> Add(TKey key, TValue value);
        IMap<TKey, TValue> Remove(TKey key);
    }
}