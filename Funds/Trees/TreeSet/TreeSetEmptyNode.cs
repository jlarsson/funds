using System.Collections;
using System.Collections.Generic;
using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeSet
{
    public class TreeSetEmptyNode<T>: AbstractEmptyNode<T>, ISet<T>
    {
        private readonly ITreeModule<T> _module;

        public TreeSetEmptyNode(TreeSetModule<object> treeSetModule)
        {
            throw new System.NotImplementedException();
        }

        public TreeSetEmptyNode(ITreeModule<T> module)
        {
            _module = module;
        }

        public override ITreeModule<T> Module
        {
            get { return _module; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            return false;
        }

        public ISet<T> Add(T value)
        {
            return (ISet<T>) Insert(value);
        }

        public ISet<T> Remove(T value)
        {
            return this;
        }
    }
}