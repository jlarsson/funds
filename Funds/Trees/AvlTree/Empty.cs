using System;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public class Empty<T> : IAvlNode<T>
    {
        private readonly IAvlTreeModule<T> _module;

        public Empty(IAvlTreeModule<T> module)
        {
            _module = module;
        }

        #region IAvlNode<T> Members

        public IAvlTreeModule<T> Module
        {
            get { return _module; }
        }

        public bool IsEmpty
        {
            get { return true; }
        }

        public byte Height
        {
            get { return 0; }
        }

        public T Value
        {
            get { throw new NotImplementedException(); }
        }

        public int BalanceFactor
        {
            get { return 0; }
        }

        public IAvlNode<T> Balance()
        {
            return this;
        }

        public IAvlNode<T> RotateRight()
        {
            return this;
        }

        public IAvlNode<T> RotateLeft()
        {
            return this;
        }

        public IAvlNode<T> DoubleRotateRight()
        {
            return this;
        }

        public IAvlNode<T> DoubleRotateLeft()
        {
            return this;
        }

        public IAvlNode<T> Left
        {
            get { return this; }
        }

        public IAvlNode<T> Right
        {
            get { return this; }
        }

        public IEnumerable<IAvlNode<T>> Enumerate()
        {
            yield break;
        }

        public IEnumerator<T2> CreateEnumerator<T2>(Func<IAvlNode<T>, T2> map)
        {
            yield break;
        }

        public IAvlNode<T> Find(T value)
        {
            return this;
        }

        public IAvlNode<T> Insert(T value)
        {
            return Module.CreateSingle(value);
        }

        public IAvlNode<T> Delete(T value)
        {
            return this;
        }

        #endregion
    }
}