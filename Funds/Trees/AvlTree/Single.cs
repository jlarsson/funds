using System;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public class Single<T> : IAvlNode<T>
    {
        private readonly IAvlTreeModule<T> _module;
        private readonly T _value;

        public Single(IAvlTreeModule<T> module, T value)
        {
            _module = module;
            _value = value;
        }

        #region IAvlNode<T> Members

        public IAvlTreeModule<T> Module
        {
            get { return _module; }
        }

        public bool IsEmpty
        {
            get { return false; }
        }

        public byte Height
        {
            get { return 1; }
        }

        public T Value
        {
            get { return _value; }
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
            get { return Module.Empty; }
        }

        public IAvlNode<T> Right
        {
            get { return Module.Empty; }
        }

        public IEnumerable<IAvlNode<T>> Enumerate()
        {
            yield return this;
        }

        public IEnumerator<T2> CreateEnumerator<T2>(Func<IAvlNode<T>, T2> map)
        {
            yield return map(this);
        }

        public IAvlNode<T> Find(T value)
        {
            return Module.Compare(_value, value) == 0 ? this : Module.Empty;
        }

        public IAvlNode<T> Update(T value)
        {
            var c = Module.Compare(_value, value);
            if (c == 0)
            {
                return Module.CreateSingle(value);
            }
            return c > 0
                       ? Module.CreateNode(Module.CreateSingle(value), _value, Module.Empty)
                       : Module.CreateNode(Module.Empty, _value, Module.CreateSingle(value));

        }

        public IAvlNode<T> Delete(T value)
        {
            return Module.Compare(_value, value) == 0 ? Module.Empty : this;
        }

        #endregion
    }
}