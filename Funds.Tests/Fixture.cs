using System;
using System.Linq;
using Funds.Trees.AvlTree;
using NUnit.Framework;

namespace Funds.Tests
{
    [TestFixture]
    public class Fixture
    {
        [Test]
        public void Avl()
        {
            var t = Enumerable.Range(0, 1024*1024)
                .Aggregate(
                    Set.Empty<int>(),
                    (c, i) => c.Add(i));

            var a = t.ToArray();
        }
        [Test]
        public void Test()
        {
            var m = Enumerable.Range(0, 16*1024)
                .Aggregate(Map.Empty<int, int>(), (c, i) => c.Add(i,i));

            var a = m.Select(kv => kv.Key).ToArray();
        }

        [Test]
        public void Q()
        {
            var q = Enumerable.Range(0, 1024)
                .Aggregate(Queue.Empty<int>(), (_q, i) => _q.Enqueue(i));

            while(!q.IsEmpty())
            {
                Console.Out.WriteLine(q.Peek());
                q = q.Dequeue();
            }
        }
    }
}
