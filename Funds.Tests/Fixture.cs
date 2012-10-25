using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace Funds.Tests
{
    public static class Combinator
    {
        public static Func<TArgument, TResult> Y<TArgument, TResult>(Func<Func<TArgument, TResult>, Func<TArgument, TResult>> f)
        {
            Func<TArgument, TResult> g = null;

            g = f(a => g(a));
            return g;
        }

        public static Func<TArgument, TResult> MemoY<TArgument, TResult>(this Func<Func<TArgument, TResult>, Func<TArgument, TResult>> f)
        {

            Func<TArgument, TResult> g = null;

            g = f(a => g(a));

            g = g.Memoize();

            return g;
        }

        public static Func<TArgument,TResult> Memoize<TArgument,TResult>(this Func<TArgument,TResult> f)
        {
            var memo = new Dictionary<TArgument, TResult>();
            return a =>
                       {
                           TResult r;
                           if (memo.TryGetValue(a, out r))
                           {
                               return r;
                           }
                           r = f(a);
                           memo.Add(a, r);
                           return r;
                       };
        }
    }
    [TestFixture]
    public class Fixture
    {
        [Test]
        public void Fib()
        {
            var fib = Combinator.MemoY<BigInteger, BigInteger>(
                f => n => n > BigInteger.One ? f(n - BigInteger.One) + f(n - BigInteger.One - BigInteger.One) : n);

            foreach (var i in Enumerable.Range(0, 100).Select(i => new BigInteger(i)))
            {
                Console.Out.WriteLine("fib({0}) = {1}", i ,fib(i));
            }

            var fact = Combinator.MemoY<BigInteger, BigInteger>(f => n => n > BigInteger.One ? n*f(n - BigInteger.One) : BigInteger.One);
            foreach (var i in Enumerable.Range(0, 100).Select(i => new BigInteger(i)))
            {
                Console.Out.WriteLine("{0}! = {1}", i, fact(i));
            }
        }

    }
}
