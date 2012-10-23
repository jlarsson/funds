using System;

namespace Funds.Stacks
{
    public class EmptyStack<T> : IStack<T>
    {
        public static readonly EmptyStack<T> Default = new EmptyStack<T>();

        #region IStack<T> Members

        public bool IsEmpty()
        {
            return true;
        }

        public T Peek()
        {
            throw new InvalidOperationException("Stack is empty");
        }

        public IStack<T> Push(T value)
        {
            return new StackNode<T>(value, this);
        }

        public IStack<T> Pop()
        {
            throw new InvalidOperationException("Stack is empty");
        }

        #endregion
    }
}