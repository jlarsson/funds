using System.Collections.Generic;

namespace Funds.Trees.RedblackTree
{
    public interface INode<T>
    {
        ITreeModule<T> Module { get; }
        bool IsEmpty { get; }
        T GetValue();
        INode<T> GetLeft();
        INode<T> GetRight();
        INode<T> Find(T value);
        INode<T> Insert(T value);
        INode<T> InsertRecursive(T value);

        IEnumerable<INode<T>> Enumerate();
        bool IsRed();
    }
}