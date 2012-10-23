﻿using System;
using System.Linq;
using NUnit.Framework;

namespace Funds.Tests
{
    [TestFixture]
    public class Fixture
    {
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