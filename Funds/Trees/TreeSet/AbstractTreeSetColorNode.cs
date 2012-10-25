using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeSet
{
    public abstract class AbstractTreeSetColorNode<T>: AbstractColorNode<T>, ISet<T>
    {
        private readonly ITreeModule<T> _module;

        protected AbstractTreeSetColorNode(ITreeModule<T> module, INode<T> left, T value, INode<T> right) : base(left, value, right)
        {
            _module = module;
        }

        public override ITreeModule<T> Module
        {
            get { return _module; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (from n in Enumerate() select n.GetValue()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
        }

        public ISet<T> Add(T value)
        {
            return (ISet<T>)base.Insert(value);
        }

        public ISet<T> Remove(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}