namespace Funds.Trees.AvlTree
{
    public interface IAvlTreeModule<T>
    {
        IAvlNode<T> Empty { get; }
        IAvlNode<T> CreateSingle(T value);
        IAvlNode<T> CreateNode(IAvlNode<T> left, T value, IAvlNode<T> right);
        int Compare(T a, T b);
    }
}