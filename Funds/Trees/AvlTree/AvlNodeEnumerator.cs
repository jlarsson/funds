using System;
using System.Collections;
using System.Collections.Generic;

namespace Funds.Trees.AvlTree
{
    public class AvlNodeEnumerator<T, TEnum>: Stack<IAvlNode<T>>, IEnumerator<TEnum>
    {
        private readonly IAvlNode<T> _node;
        private readonly Func<IAvlNode<T>, TEnum> _map;
        private bool _started;
        public AvlNodeEnumerator(IAvlNode<T> node, Func<IAvlNode<T>, TEnum> map)
        {
            _node = node;
            _map = map;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!_started)
            {
                var n = _node;
                while (!n.IsEmpty)
                {
                    Push(n);
                    n = n.Left;
                }
                _started = true;
            }
            if (Count > 0)
            {
                var t = Pop();
                Current = _map(t);
                t = t.Right;
                while (!t.IsEmpty)
                {
                    Push(t);
                    t = t.Left;
                }
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Clear();
            _started = false;
        }

        public TEnum Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}