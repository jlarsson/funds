using System;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public interface IAvlNode<T>
    {
        IAvlTreeModule<T> Module { get; }
        bool IsEmpty { get; }
        byte Height { get; }
        T Value { get; }
        int BalanceFactor { get; }
        IAvlNode<T> Left { get; }
        IAvlNode<T> Right { get; }
        IAvlNode<T> Balance();
        IAvlNode<T> RotateRight();
        IAvlNode<T> RotateLeft();
        IAvlNode<T> DoubleRotateRight();
        IAvlNode<T> DoubleRotateLeft();
        IEnumerable<IAvlNode<T>> Enumerate();
        IEnumerator<TEnum> CreateEnumerator<TEnum>(Func<IAvlNode<T>, TEnum> map);
        IAvlNode<T> Find(T value);
        IAvlNode<T> Update(T value);
        IAvlNode<T> Delete(T value);
    }
}