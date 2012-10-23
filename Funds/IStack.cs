namespace Funds
{
    public interface IStack<T>
    {
        bool IsEmpty();
        T Peek();
        IStack<T> Push(T value);
        IStack<T> Pop();
    }
}