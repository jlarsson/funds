using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Funds.Trees.AvlTree.Set
{
    public class SetNode<T>: Node<T>, ISet<T>
    {
        public SetNode(IAvlTreeModule<T> module, IAvlNode<T> left, T value, IAvlNode<T> right) : base(module, left, value, right)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return CreateEnumerator(n => n.Value);
            return (Enumerate().Select(n => n.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            return !Find(value).IsEmpty;
        }

        public ISet<T> Add(T value)
        {
            return (ISet<T>) Insert(value);
        }

        public ISet<T> Remove(T value)
        {
            return (ISet<T>) Delete(value);
        }
    }
}