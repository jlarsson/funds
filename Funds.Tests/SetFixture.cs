using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Funds.Tests
{
    [TestFixture]
    public class SetFixture
    {
        [Test]
        public void SetCanBeInitialized()
        {
            var s = new Set<int> {1, 2, 3, 4, 5};

        }

        [Test]
        public void SetIsAnOrderedCollection()
        {
            var set = Enumerable.Range(0, 1024).Shuffle()
                .Aggregate(
                    Set.Empty<int>(),
                    (s, i) => s.Add(i));

            Assert.That(set.ToArray(), Is.EqualTo(Enumerable.Range(0, 1024).ToArray()));
        }

        [Test]
        public void Remove()
        {
            var numbers = Enumerable.Range(0, 16*1024).ToArray();
            var numbersToRemove = new HashSet<int>(from n in numbers where ((n%3) == 0) || ((n%7) == 0) select n);
            var remainingNumbers = (from n in numbers where !numbersToRemove.Contains(n) select n).ToArray();

            // Create initial set
            var set = numbers
                .Aggregate(Set.Empty<int>(),(s, i) => s.Add(i));

            // Remove some numbers
            set = numbersToRemove.Aggregate(set, (s, i) => s.Remove(i));

            Assert.That(set.ToArray(), Is.EqualTo(remainingNumbers));
        }

        [Test]
        public void RemoveAll()
        {
            var numbers = Enumerable.Range(0, 16 * 1024).ToArray();
            var numbersToRemove = numbers;
            var remainingNumbers = new int[0];

            // Create initial set
            var set = numbers
                .Aggregate(Set.Empty<int>(), (s, i) => s.Add(i));

            // Remove some numbers
            set = numbersToRemove.Aggregate(set, (s, i) => s.Remove(i));

            Assert.That(set.ToArray(), Is.EqualTo(remainingNumbers));
        }

        [Test]
        public void CustomComparer()
        {
            var strings = new[] {"a", "A", "b", "B"};

            var set = strings.Aggregate(
                Set.Empty(StringComparer.OrdinalIgnoreCase),
                (s, v) => s.Add(v));

            Assert.That(set.Select(s => s.ToLower()).ToArray(),Is.EqualTo(new[]{"a","b"}));
        }

        [Test]
        public void AddingDuplicateValueOverwrites()
        {
            // Initialize with lowercase values
            var s = Set.Empty(StringComparer.OrdinalIgnoreCase)
                .Add("a").Add("b");

            // Overwrite with uppercase values
            s = s.Add("A").Add("B");

            Assert.That(s.ToArray(), Is.EqualTo(new[] { "A", "B" }));
        }
    }
}