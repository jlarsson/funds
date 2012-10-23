using System;

namespace Funds.Queues
{
    public class Deque<T> : IDeque<T>
    {
        private static readonly IDeque<T> empty = new EmptyDeque();

        private readonly Dequelette _left;
        private readonly IDeque<Dequelette> _middle;
        private readonly Dequelette _right;

        private Deque(Dequelette left, IDeque<Dequelette> middle, Dequelette right)
        {
            _left = left;
            _middle = middle;
            _right = right;
        }

        public static IDeque<T> Empty
        {
            get { return empty; }
        }

        #region IDeque<T> Members

        public bool IsEmpty()
        {
            return false;
        }

        public T Peek()
        {
            return PeekLeft();
        }

        public IQueue<T> Enqueue(T value)
        {
            return EnqueueRight(value);
        }

        public IQueue<T> Dequeue()
        {
            return DequeueLeft();
        }

        public IDeque<T> EnqueueLeft(T value)
        {
            if (!_left.Full)
                return new Deque<T>(_left.EnqueueLeft(value), _middle, _right);
            return new Deque<T>(
                new Two(value, _left.PeekLeft()),
                _middle.EnqueueLeft(_left.DequeueLeft()),
                _right);
        }

        public IDeque<T> EnqueueRight(T value)
        {
            if (!_right.Full)
                return new Deque<T>(_left, _middle, _right.EnqueueRight(value));
            return new Deque<T>(
                _left,
                _middle.EnqueueRight(_right.DequeueRight()),
                new Two(_right.PeekRight(), value));
        }

        public IDeque<T> DequeueLeft()
        {
            if (_left.Size > 1)
                return new Deque<T>(_left.DequeueLeft(), _middle, _right);
            if (!_middle.IsEmpty())
                return new Deque<T>(_middle.PeekLeft(), _middle.DequeueLeft(), _right);
            if (_right.Size > 1)
                return new Deque<T>(new One(_right.PeekLeft()), _middle, _right.DequeueLeft());
            return new SingleDeque(_right.PeekLeft());
        }

        public IDeque<T> DequeueRight()
        {
            if (_right.Size > 1)
                return new Deque<T>(_left, _middle, _right.DequeueRight());
            if (!_middle.IsEmpty())
                return new Deque<T>(_left, _middle.DequeueRight(), _middle.PeekRight());
            if (_left.Size > 1)
                return new Deque<T>(_left.DequeueRight(), _middle, new One(_left.PeekRight()));
            return new SingleDeque(_left.PeekRight());
        }

        public T PeekLeft()
        {
            return _left.PeekLeft();
        }

        public T PeekRight()
        {
            return _right.PeekRight();
        }

        #endregion

        #region Nested type: Dequelette

        private abstract class Dequelette
        {
            public abstract int Size { get; }

            public virtual bool Full
            {
                get { return false; }
            }

            public abstract T PeekLeft();
            public abstract T PeekRight();
            public abstract Dequelette EnqueueLeft(T t);
            public abstract Dequelette EnqueueRight(T t);
            public abstract Dequelette DequeueLeft();
            public abstract Dequelette DequeueRight();
        }

        #endregion

        #region Nested type: EmptyDeque

        private sealed class EmptyDeque : IDeque<T>
        {
            #region IDeque<T> Members

            public bool IsEmpty()
            {
                return true;
            }

            public T Peek()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            public IQueue<T> Enqueue(T value)
            {
                return EnqueueRight(value);
            }

            public IQueue<T> Dequeue()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            public IDeque<T> EnqueueLeft(T value)
            {
                return new SingleDeque(value);
            }

            public IDeque<T> EnqueueRight(T value)
            {
                return new SingleDeque(value);
            }

            public IDeque<T> DequeueLeft()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            public IDeque<T> DequeueRight()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            public T PeekLeft()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            public T PeekRight()
            {
                throw new InvalidOperationException("Deque is empty ");
            }

            #endregion
        }

        #endregion

        #region Nested type: Four

        private class Four : Dequelette
        {
            private readonly T _v1;
            private readonly T _v2;
            private readonly T _v3;
            private readonly T _v4;

            public Four(T t1, T t2, T t3, T t4)
            {
                _v1 = t1;
                _v2 = t2;
                _v3 = t3;
                _v4 = t4;
            }

            public override int Size
            {
                get { return 4; }
            }

            public override bool Full
            {
                get { return true; }
            }

            public override T PeekLeft()
            {
                return _v1;
            }

            public override T PeekRight()
            {
                return _v4;
            }

            public override Dequelette EnqueueLeft(T t)
            {
                throw new Exception("Impossible");
            }

            public override Dequelette EnqueueRight(T t)
            {
                throw new Exception("Impossible");
            }

            public override Dequelette DequeueLeft()
            {
                return new Three(_v2, _v3, _v4);
            }

            public override Dequelette DequeueRight()
            {
                return new Three(_v1, _v2, _v3);
            }
        }

        #endregion

        #region Nested type: One

        private class One : Dequelette
        {
            private readonly T _v1;

            public One(T t1)
            {
                _v1 = t1;
            }

            public override int Size
            {
                get { return 1; }
            }

            public override T PeekLeft()
            {
                return _v1;
            }

            public override T PeekRight()
            {
                return _v1;
            }

            public override Dequelette EnqueueLeft(T t)
            {
                return new Two(t, _v1);
            }

            public override Dequelette EnqueueRight(T t)
            {
                return new Two(_v1, t);
            }

            public override Dequelette DequeueLeft()
            {
                throw new Exception("Impossible");
            }

            public override Dequelette DequeueRight()
            {
                throw new Exception("Impossible");
            }
        }

        #endregion

        #region Nested type: SingleDeque

        private sealed class SingleDeque : IDeque<T>
        {
            private readonly T _item;

            public SingleDeque(T t)
            {
                _item = t;
            }

            #region IDeque<T> Members

            public bool IsEmpty()
            {
                return false;
            }

            public T Peek()
            {
                return PeekLeft();
            }

            public IQueue<T> Enqueue(T value)
            {
                return EnqueueRight(value);
            }

            public IQueue<T> Dequeue()
            {
                return DequeueLeft();
            }

            public IDeque<T> EnqueueLeft(T value)
            {
                return new Deque<T>(new One(value), Deque<Dequelette>.Empty, new One(_item));
            }

            public IDeque<T> EnqueueRight(T value)
            {
                return new Deque<T>(new One(_item), Deque<Dequelette>.Empty, new One(value));
            }

            public IDeque<T> DequeueLeft()
            {
                return Empty;
            }

            public IDeque<T> DequeueRight()
            {
                return Empty;
            }

            public T PeekLeft()
            {
                return _item;
            }

            public T PeekRight()
            {
                return _item;
            }

            #endregion
        }

        #endregion

        #region Nested type: Three

        private class Three : Dequelette
        {
            private readonly T _v1;
            private readonly T _v2;
            private readonly T _v3;

            public Three(T t1, T t2, T t3)
            {
                _v1 = t1;
                _v2 = t2;
                _v3 = t3;
            }

            public override int Size
            {
                get { return 3; }
            }

            public override T PeekLeft()
            {
                return _v1;
            }

            public override T PeekRight()
            {
                return _v3;
            }

            public override Dequelette EnqueueLeft(T t)
            {
                return new Four(t, _v1, _v2, _v3);
            }

            public override Dequelette EnqueueRight(T t)
            {
                return new Four(_v1, _v2, _v3, t);
            }

            public override Dequelette DequeueLeft()
            {
                return new Two(_v2, _v3);
            }

            public override Dequelette DequeueRight()
            {
                return new Two(_v1, _v2);
            }
        }

        #endregion

        #region Nested type: Two

        private class Two : Dequelette
        {
            private readonly T _v1;
            private readonly T _v2;

            public Two(T t1, T t2)
            {
                _v1 = t1;
                _v2 = t2;
            }

            public override int Size
            {
                get { return 2; }
            }

            public override T PeekLeft()
            {
                return _v1;
            }

            public override T PeekRight()
            {
                return _v2;
            }

            public override Dequelette EnqueueLeft(T t)
            {
                return new Three(t, _v1, _v2);
            }

            public override Dequelette EnqueueRight(T t)
            {
                return new Three(_v1, _v2, t);
            }

            public override Dequelette DequeueLeft()
            {
                return new One(_v2);
            }

            public override Dequelette DequeueRight()
            {
                return new One(_v1);
            }
        }

        #endregion
    }
}