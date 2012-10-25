using System.Collections.Generic;
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
    }
}