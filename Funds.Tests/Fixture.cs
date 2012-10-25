using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;

namespace Funds.Tests
{
    public static class EnumerableExtensions
    {
        static readonly RNGCryptoServiceProvider RngCryptoServiceProvider = new RNGCryptoServiceProvider();
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var randomIntegerBuffer = new byte[4];
            Func<int> rand = () =>
                                 {
                                     RngCryptoServiceProvider.GetBytes(randomIntegerBuffer);
                                     return BitConverter.ToInt32(randomIntegerBuffer, 0);
                                 };
            return from item in enumerable
                   let rec = new {item, rnd = rand()}
                   orderby rec.rnd
                   select rec.item;
        }
    }

    [TestFixture]
    public class Fixture
    {
        [Test]
        public void Avl()
        {
            var l = Enumerable.Range(0, 1024).Shuffle().Distinct().ToArray();

            var t = Enumerable.Range(0, 1024).Shuffle()
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
