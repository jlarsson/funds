namespace Funds.Stacks
{
    public class StackNode<T> : IStack<T>
    {
        public StackNode(T head, IStack<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public T Head { get; set; }
        public IStack<T> Tail { get; set; }

        #region IStack<T> Members

        public bool IsEmpty()
        {
            return false;
        }

        public T Peek()
        {
            return Head;
        }

        public IStack<T> Push(T value)
        {
            return new StackNode<T>(value, this);
        }

        public IStack<T> Pop()
        {
            return Tail;
        }

        #endregion
    }
}