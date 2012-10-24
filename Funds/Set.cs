using Funds.Trees.AvlTree.Set;

namespace Funds
{
    public static class Set
    {
        public static ISet<T> Empty<T>()
        {
            //return new TreeSetEmptyNode<T>(new TreeSetModule<T>(Comparer<T>.Default));
            return (ISet<T>)new SetModule<T>().Empty;
        }
    }
}