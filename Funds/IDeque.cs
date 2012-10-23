namespace Funds
{
    public interface IDeque<T> : IQueue<T>
    {
        T PeekLeft();
        T PeekRight();
        IDeque<T> EnqueueLeft(T value);
        IDeque<T> EnqueueRight(T value);
        IDeque<T> DequeueLeft();
        IDeque<T> DequeueRight();
    }
}