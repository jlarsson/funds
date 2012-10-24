using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public class Node<T> : IAvlNode<T>
    {
        private readonly byte _height;
        private readonly IAvlNode<T> _left;
        private readonly IAvlTreeModule<T> _module;
        private readonly IAvlNode<T> _right;
        private readonly T _value;

        public Node(IAvlTreeModule<T> module, IAvlNode<T> left, T value, IAvlNode<T> right)
        {
            _module = module;
            _value = value;
            _left = left;
            _right = right;
            var lh = left.Height;
            var rh = right.Height;
            _height = (byte) (1 + ((lh > rh) ? lh : rh));
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
            get { return _height; }
        }

        public T Value
        {
            get { return _value; }
        }

        public int BalanceFactor
        {
            get { return _left.Height - _right.Height; }
        }

        public IAvlNode<T> Balance()
        {
            var bf = BalanceFactor;
            if (bf >= 2)
            {
                return _left.BalanceFactor >= 1 ? RotateRight() : DoubleRotateRight();
            }
            if (bf <= -2)
            {
                return _right.BalanceFactor <= -1 ? RotateLeft() : DoubleRotateLeft();
            }
            return this;
        }

        public IAvlNode<T> RotateRight()
        {
            return Module.CreateNode(_left.Left, _left.Left.Value, Module.CreateNode(_left.Right, _value, _right));
        }

        public IAvlNode<T> RotateLeft()
        {
            return Module.CreateNode(
                Module.CreateNode(_left, _value, _right.Left),
                _right.Value,
                _right.Right
                );
        }

        public IAvlNode<T> DoubleRotateRight()
        {
            return Module.CreateNode(_left.RotateLeft(), _value, _right).RotateRight();
        }

        public IAvlNode<T> DoubleRotateLeft()
        {
            return Module.CreateNode(_left, _value, _right.RotateRight()).RotateLeft();
        }

        public IAvlNode<T> Left
        {
            get { return _left; }
        }

        public IAvlNode<T> Right
        {
            get { return _right; }
        }

        public IEnumerable<IAvlNode<T>> Enumerate()
        {
            var s = new Stack<IAvlNode<T>>();
            IAvlNode<T> n = this;
            while (!n.IsEmpty)
            {
                s.Push(n);
                n = n.Left;
            }
            while (s.Count > 0)
            {
                var t = s.Pop();
                yield return t;
                t = t.Right;
                while (!t.IsEmpty)
                {
                    s.Push(t);
                    t = t.Left;
                }
            }
        }

        public IAvlNode<T> Find(T value)
        {
            IAvlNode<T> n = this;
            while (!n.IsEmpty)
            {
                var c = Module.Compare(n.Value, value);
                if (c == 0)
                {
                    break;
                }
                n = c > 0 ? n.Left : n.Right;
            }
            return n;
        }

        public IAvlNode<T> Insert(T value)
        {
            var c = Module.Compare(_value, value);
            if (c == 0)
            {
                return Module.CreateNode(_left, value, _right);
            }
            return
                (c > 0
                     ? Module.CreateNode(_left.Insert(value), _value, _right)
                     : Module.CreateNode(_left, _value, _right.Insert(value))).Balance();
        }

        #endregion
    }
}