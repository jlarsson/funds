using System;
using System.Linq;
using NUnit.Framework;

namespace Funds.Tests
{
    [TestFixture]
    public class QueueFixture
    {
        [Test]
        public void DequeueThrowsOnEmptyQueue()
        {
            Assert.Throws<InvalidOperationException>(() => Queue.Empty<int>().Dequeue());
        }

        [Test]
        public void Test()
        {
            var que = Enumerable.Range(0, 1024).Aggregate(Queue.Empty<int>(), (q, i) => q.Enqueue(i));

            var dequeued = new System.Collections.Generic.List<int>();
            while(!que.IsEmpty())
            {
                dequeued.Add(que.Peek());
                que = que.Dequeue();
            }

            Assert.That(
                dequeued.ToArray(),
                Is.EqualTo(Enumerable.Range(0, 1024).ToArray())
                );
        }
    }
}