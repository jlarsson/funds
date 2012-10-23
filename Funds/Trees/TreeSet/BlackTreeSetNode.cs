using Funds.Trees.RedblackTree;

namespace Funds.Trees.TreeSet
{
    public class BlackTreeSetNode<T> : AbstractTreeSetColorNode<T>
    {
        public BlackTreeSetNode(ITreeModule<T> module, INode<T> left, T value, INode<T> right)
            : base(module, left, value, right)
        {
        }

        protected override NodeColor Color
        {
            get { return NodeColor.Black; }
        }
    }
}
