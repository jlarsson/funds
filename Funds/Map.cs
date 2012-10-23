using System.Collections.Generic;
using Funds.Trees.TreeMap;

namespace Funds
{
    public static class Map
    {
        public static IMap<TKey, TValue> Empty<TKey, TValue>()
        {
            return new TreeMapEmptyNode<TKey, TValue>(new TreeMapModule<TKey, TValue>(Comparer<TKey>.Default));
        }
    }
}