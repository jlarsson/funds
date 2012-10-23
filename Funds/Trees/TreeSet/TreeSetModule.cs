using System.Collections.Generic;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeSet
{
    public class TreeSetModule<T>: ITreeModule<T>
    {
        public IComparer<T> Comparer { get; private set; }

        public TreeSetModule(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public int Compare(T a, T b)
        {
            return Comparer.Compare(a, b);
        }

        public INode<T> CreateEmpty()
        {
            return new TreeSetEmptyNode<T>(this);
        }

        public INode<T> CreateRed(INode<T> left, T value, INode<T> right)
        {
            return new RedTreeSetNode<T>(this, left, value, right);
        }

        public INode<T> CreateBlack(INode<T> left, T value, INode<T> right)
        {
            return new BlackTreeSetNode<T>(this, left, value, right);
        }
    }
}