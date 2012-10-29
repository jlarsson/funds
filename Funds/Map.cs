using System;
using System.Collections.Generic;
using System.Linq;
using Funds.Trees.AvlTree.Map;

namespace Funds
{
    public static class Map
    {
        public static IMap<TKey, TValue> Empty<TKey, TValue>()
        {
            return (IMap<TKey, TValue>) MapModule<TKey, TValue>.Default.Empty;
        }

        public static IMap<TKey, TValue> Empty<TKey, TValue>(IComparer<TKey> comparer)
        {
            return (IMap<TKey,TValue>)new MapModule<TKey, TValue>(comparer).Empty;
        }

        public static IMap<TKey, TValue> ToMap<T, TKey, TValue>(this IEnumerable<T> enumerable, Func<T, TKey> key, Func<T, TValue> value)
        {
            return enumerable.Aggregate(Empty<TKey, TValue>(), (m, i) => m.Add(key(i), value(i)));
        }

        public static IMap<TKey,TValue> ToMap<T,TKey,TValue>(this IEnumerable<T> enumerable,Func<T,TKey> key, Func<T,TValue> value, IComparer<TKey> comparer)
        {
            return enumerable.Aggregate(Empty<TKey, TValue>(comparer), (m, i) => m.Add(key(i), value(i)));
        }

        public static IMap<TKey, TValue> ToMap<TKey, TValue>(this IEnumerable<KeyValuePair<TKey,TValue>> enumerable)
        {
            return enumerable.Aggregate(Empty<TKey, TValue>(), (m, kv) => m.Add(kv.Key, kv.Value));
        }

        public static IMap<TKey, TValue> ToMap<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> enumerable, IComparer<TKey> comparer)
        {
            return enumerable.Aggregate(Empty<TKey, TValue>(comparer), (m, kv) => m.Add(kv.Key, kv.Value));
        }

        public static IMap<TKey, TValue> Add<T, TKey, TValue>(this IMap<TKey,TValue> map, IEnumerable<T> enumerable, Func<T, TKey> key, Func<T, TValue> value)
        {
            return enumerable.Aggregate(map, (m, i) => m.Add(key(i), value(i)));
        }

        public static IMap<TKey, TValue> Add<TKey, TValue>(this IMap<TKey, TValue> map, IEnumerable<KeyValuePair<TKey,TValue>> enumerable)
        {
            return enumerable.Aggregate(map, (m, kv) => m.Add(kv.Key,kv.Value));
        }

        public static IMap<TKey, TValue> Remove<TKey, TValue>(this IMap<TKey, TValue> map, IEnumerable<TKey> keys)
        {
            return keys.Aggregate(map, (m, k) => m.Remove(k));
        }
    }
}