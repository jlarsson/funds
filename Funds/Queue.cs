using Funds.Queues;

namespace Funds
{
    public static class Queue
    {
        public static IQueue<T> Empty<T>()
        {
            return Deque<T>.Empty;
        }
    }
}