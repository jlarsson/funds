using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeSet
{
    public class RedTreeSetNode<T>: AbstractTreeSetColorNode<T>
    {
        public RedTreeSetNode(ITreeModule<T> module, INode<T> left, T value, INode<T> right) : base(module, left, value, right)
        {
        }

        protected override NodeColor Color
        {
            get { return NodeColor.Red; }
        }
    }
}