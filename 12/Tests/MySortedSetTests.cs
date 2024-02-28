using _12;

namespace Tests
{
    [TestFixture]
    public class MySortedSetTests
    {
        public static IEnumerable<object> Sets
        {
            get
            {
                MySortedSet<int> first = new();
                MySortedSetExperemental<int> second = new();
                for (var i = 0; i < 1000; i++)
                {
                    first.Add(i);
                    second.Add(i);
                }
                first.Clear();
                second.Clear();
                for (var i = 0; i < 100; i++)
                {
                    first.Add(i);
                    second.Add(i);
                }
                return [first, second];
            }
        }

        [TestCaseSource(nameof(Sets))]
        public void Add(ICollection<int> set)
        {
            for (var i = 0; i < 100; i++) set.Add(i);
            Assert.That(set, Is.EquivalentTo(Enumerable.Range(0, 100)));
        }

        [TestCaseSource(nameof(Sets))]
        public void Contains(ICollection<int> set)
        {
            Assert.That(set.Contains(100001), Is.False);
        }

        [TestCaseSource(nameof(Sets))]
        public void Remove(ICollection<int> set)
        {
            Assert.That(set.Remove(77), Is.True);
        }

        [TestCaseSource(nameof(Sets))]
        public void CopyTo(ICollection<int> set)
        {
            int[] array = new int[500000];
            set.CopyTo(array, 5000);
            Assert.That(array, Is.EquivalentTo(Enumerable.Repeat(0, 5000)
                .Concat(Enumerable.Range(0, 100))
                .Concat(Enumerable.Repeat(0, 500000 - 100 - 5000))));
        }

        [TestCaseSource(nameof(Sets))]
        public void CheckCount(ICollection<int> set)
        {
            Assert.That(set, Has.Count.EqualTo(100));
        }

        [TestCaseSource(nameof(Sets))]
        public void Equals(ICollection<int> set)
        {
            if (set.GetType().FullName == "_12.MySortedSet")
            {
                var first = (MySortedSet<int>)set;
                var second = (MySortedSet<int>)first.Clone();
                first.Remove(77);
                second.Remove(77);
                Assert.That(first, Is.EqualTo(second));
            }
            else
            {
                var first = (MySortedSetExperemental<int>)set;
                var second = (MySortedSetExperemental<int>)first.Clone();
                first.Remove(77);
                second.Remove(77);
                Assert.That(first, Is.EqualTo(second));
            }
        }

        [TestCaseSource(nameof(Sets))]
        public void ShallowCopy(ICollection<int> set)
        {
            if (set.GetType().FullName == "_12.MySortedSet")
            {
                var first = (MySortedSet<int>)set;
                var second = (MySortedSet<int>)first.ShallowCopy();
                first.Remove(77);
                Assert.That(first, Is.EqualTo(second));
            }
            else
            {
                var first = (MySortedSetExperemental<int>)set;
                var second = (MySortedSetExperemental<int>)first.ShallowCopy();
                first.Remove(77);
                Assert.That(first, Is.EqualTo(second));
            }
        }
    }
}