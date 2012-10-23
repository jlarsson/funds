using System.Collections.Generic;
using Funds.Trees.TreeSet;

namespace Funds
{
    public static class Set
    {
        public static ISet<T> Empty<T>()
        {
            return new TreeSetEmptyNode<T>(new TreeSetModule<T>(Comparer<T>.Default));
        }
    }
}