using System;
using System.Collections.Generic;

namespace Funds.Trees.RedblackTree
{
    public abstract class AbstractColorNode<T> : INode<T>
    {
        private readonly INode<T> _left;
        private readonly INode<T> _right;
        private readonly T _value;

        protected AbstractColorNode(INode<T> left, T value, INode<T> right)
        {
            _left = left;
            _value = value;
            _right = right;
        }

        protected abstract NodeColor Color { get; }

        #region INode<T> Members

        public abstract ITreeModule<T> Module { get; }

        public bool IsEmpty()
        {
            return false;
        }

        public T GetValue()
        {
            return _value;
        }

        public INode<T> GetLeft()
        {
            return _left;
        }

        public INode<T> GetRight()
        {
            return _right;
        }

        public INode<T> Find(T value)
        {
            INode<T> n = this;
            while (n != null)
            {
                var c = Module.Compare(n.GetValue(), value);
                if (c == 0)
                {
                    return n;
                }
                n = c > 0 ? _left : _right;
            }
            return null;
        }

        public INode<T> Insert(T value)
        {
            var n = InsertRecursive(value);
            return n.IsRed() ? Module.CreateBlack(n.GetLeft(), n.GetValue(), n.GetRight()) : n;
        }

        public INode<T> InsertRecursive(T value)
        {
            var c = Module.Compare(_value, value);
            if (c == 0)
            {
                // Duplicate
                throw new ArgumentException("Duplicate key");
            }
            if (c > 0)
            {
                return Balance(Color, _left.InsertRecursive(value), _value, _right);
            }
            return Balance(Color, _left, _value, _right.InsertRecursive(value));
        }

        public IEnumerable<INode<T>> Enumerate()
        {
            var s = new Stack<INode<T>>();
            INode<T> n = this;
            while (!n.IsEmpty())
            {
                s.Push(n);
                n = n.GetLeft();
            }
            while (s.Count > 0)
            {
                var t = s.Pop();
                yield return t;
                t = t.GetRight();
                while (!t.IsEmpty())
                {
                    s.Push(t);
                    t = t.GetLeft();
                }
            }
        }

        public bool IsRed()
        {
            return Color == NodeColor.Red;
        }

        #endregion

        protected INode<T> Balance(NodeColor color, INode<T> l, T v, INode<T> r)
        {
            /* 
        | B, T(R, T(R, a, x, b), y, c), z, d            (* Left, left *)
        | B, T(R, a, x, T(R, b, y, c)), z, d            (* Left, right *)
        | B, a, x, T(R, T(R, b, y, c), z, d)            (* Right, left *)
        | B, a, x, T(R, b, y, T(R, c, z, d))            (* Right, right *)
            -> T(R, T(B, a, x, b), y, T(B, c, z, d))
        | c, l, x, r -> T(c, l, x, r)
             */
            var module = Module;
            if (color == NodeColor.Black)
            {
                var ll = l.GetLeft();
                var lr = l.GetRight();
                var rl = r.GetLeft();
                var rr = r.GetRight();

                var balanceBlack = false;
                INode<T> a = null, b = null, c = null, d = null;
                T x = default(T), y = default(T), z = default(T);
                if (l.IsRed() && ll.IsRed())
                {
                    // B, T(R, T(R, a, x, b), y, c), z, d -> T(R, T(B, a, x, b), y, T(B, c, z, d))
                    a = ll.GetLeft();
                    x = ll.GetValue();
                    b = ll.GetRight();
                    y = l.GetValue();
                    c = l.GetRight();
                    z = v;
                    d = r;
                    balanceBlack = true;
                }
                else if (l.IsRed() && lr.IsRed())
                {
                    // B, T(R, a, x, T(R, b, y, c)), z, d
                    a = ll;
                    x = l.GetValue();
                    b = lr.GetLeft();
                    y = lr.GetValue();
                    c = lr.GetLeft();
                    z = v;
                    d = r;
                    balanceBlack = true;
                }
                else if (r.IsRed() && rl.IsRed())
                {
                    // B, a, x, T(R, T(R, b, y, c), z, d)
                    a = l;
                    x = v;
                    b = rl.GetLeft();
                    y = rl.GetValue();
                    c = rl.GetRight();
                    z = r.GetValue();
                    d = rr;
                    balanceBlack = true;
                }
                else if (r.IsRed() && rr.IsRed())
                {
                    // B, a, x, T(R, b, y, T(R, c, z, d))
                    a = l;
                    x = v;
                    b = r.GetLeft();
                    y = r.GetValue();
                    c = rr.GetLeft();
                    z = rr.GetValue();
                    d = rr.GetLeft();
                    balanceBlack = true;
                }
                if (balanceBlack)
                {
                    module.CreateRed(
                        module.CreateBlack(a, x, b),
                        y,
                        module.CreateBlack(c, z, d)
                        );
                }
            }
            return color == NodeColor.Red
                       ? module.CreateRed(l, v, r)
                       : module.CreateBlack(l, v, r);
        }
    }
}