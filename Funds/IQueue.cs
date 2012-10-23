namespace Funds
{
    public interface IQueue<T>
    {
        bool IsEmpty();
        T Peek();
        IQueue<T> Enqueue(T value);
        IQueue<T> Dequeue();
    }
}