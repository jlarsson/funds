using System;
using System.Collections.Generic;

namespace Funds.Trees.RedblackTree
{
    public abstract class AbstractEmptyNode<T> : INode<T>
    {
        #region INode<T> Members

        public abstract ITreeModule<T> Module { get; }

        public bool IsEmpty
        {
            get { return true; }
        }

        public T GetValue()
        {
            throw new InvalidOperationException("Empty tree");
        }

        public INode<T> GetLeft()
        {
            //throw new InvalidOperationException("Empty tree");
            return this;
        }

        public INode<T> GetRight()
        {
            //throw new InvalidOperationException("Empty tree");
            return this;
        }

        public INode<T> Find(T value)
        {
            return null;
        }

        public INode<T> Insert(T value)
        {
            return Module.CreateBlack(this, value, this);
        }

        public INode<T> InsertRecursive(T value)
        {
            return Module.CreateRed(this, value, this);
        }

        public IEnumerable<INode<T>> Enumerate()
        {
            yield break;
        }

        public bool IsRed()
        {
            return false;
        }

        #endregion
    }
}