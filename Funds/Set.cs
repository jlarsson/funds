using System.Collections.Generic;
using System.Linq;
using Funds.Trees.AvlTree.Set;

namespace Funds
{
    public static class Set
    {
        public static ISet<T> Empty<T>()
        {
            return (ISet<T>) SetModule<T>.Default.Empty;
        }

        public static ISet<T> Empty<T>(IComparer<T> comparer)
        {
            return (ISet<T>) new SetModule<T>(comparer).Empty;
        }

        public static ISet<T> Add<T>(this ISet<T> set, IEnumerable<T> values)
        {
            return values.Aggregate(set, (s, v) => s.Add(v));
        }

        public static ISet<T> Remove<T>(this ISet<T> set, IEnumerable<T> values)
        {
            return values.Aggregate(set, (s, v) => s.Remove(v));
        }

        public static ISet<T> ToSet<T>(IEnumerable<T> enumerable)
        {
            return enumerable.Aggregate(Empty<T>(), (s, i) => s.Add(i));
        }

        public static ISet<T> ToSet<T>(this IEnumerable<T> enumerable, IComparer<T> comparer)
        {
            return enumerable.Aggregate(Empty(comparer), (s, i) => s.Add(i));
        }
    }
}