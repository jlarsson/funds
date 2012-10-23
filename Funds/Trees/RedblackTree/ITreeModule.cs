namespace Funds.Trees.RedblackTree
{
    public interface ITreeModule<T>
    {
        int Compare(T a, T b);
        INode<T> CreateEmpty();
        INode<T> CreateRed(INode<T> left, T value, INode<T> right);
        INode<T> CreateBlack(INode<T> left, T value, INode<T> right);
    }
}