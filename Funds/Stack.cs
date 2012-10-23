using Funds.Stacks;

namespace Funds
{
    public static class Stack
    {
        public static IStack<T> Empty<T>()
        {
            return EmptyStack<T>.Default;
        }
    }
}