using System;
using System.Linq;
using NUnit.Framework;

namespace Funds.Tests
{
    [TestFixture]
    public class MapFixture
    {
        [Test]
        public void CustomComparer()
        {
            var map = Map.Empty<string, int>(StringComparer.OrdinalIgnoreCase)
                .Add("a", 1).Add("A", 1);

            Assert.That(map.TryGetValue("a"), Is.EqualTo(1));
            Assert.That(map.TryGetValue("A"), Is.EqualTo(1));
        }

        [Test]
        public void MapIsOrdered()
        {
            var map = Enumerable.Range(0, 1024).Shuffle().ToMap(i => i, i => i);
            Assert.That(map.Select(kv => kv.Key).ToArray(), Is.EqualTo(Enumerable.Range(0,1024)));
        }

        [Test]
        public void AddingDuplicateValueOverwrites()
        {
            // Initialize with lowercase values
            var m = Map.Empty<int,int>().Add(1,10).Add(2,20);

            // Overwrite with uppercase values
            m = m.Add(1, 11).Add(2, 22);

            Assert.That(m.TryGetValue(1), Is.EqualTo(11));
            Assert.That(m.TryGetValue(2), Is.EqualTo(22));
        }

        [Test]
        public void TryGettingMissingValueReturnsSpecifiedDefault()
        {
            var m = Map.Empty<int, int>();

            Assert.That(m.TryGetValue(1,12345), Is.EqualTo(12345));
        }

        [Test]
        public void ContainsKey()
        {
            const int n = 1024;
            var m = Enumerable.Range(0, n).ToMap(i => i, i => i);

            Assert.IsTrue(Enumerable.Range(0,n).All(m.ContainsKey));
            
            Assert.IsFalse(Enumerable.Range(n,n).All(m.ContainsKey));
        }
    }
}