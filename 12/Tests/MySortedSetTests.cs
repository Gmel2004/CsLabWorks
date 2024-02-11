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
                MySortedSet<int> set = new();
                MyOtherSortedSet<int> other = new();
                for (var i = 0; i < 1_000_000; i++)
                {
                    set.Add(i);
                    other.Add(i);
                }
                set.Clear();
                other.Clear();
                for (var i = 0; i < 100_000; i++)
                {
                    set.Add(i);
                    other.Add(i);
                }
                return [set, other];
            }
        }

        [TestCaseSource(nameof(Sets))]
        public void Add(ICollection<int> set)
        {
            for (var i = 0; i < 1_000_000; i++) set.Add(i);
            Assert.That(set, Is.EquivalentTo(Enumerable.Range(0, 1_000_000)));
        }

        [TestCaseSource(nameof(Sets))]
        public void Contains(ICollection<int> set)
        {
            Assert.That(set.Contains(100001), Is.False);
        }

        [TestCaseSource(nameof(Sets))]
        public void Remove(ICollection<int> set)
        {
            Assert.That(set.Remove(100001), Is.False);
        }

        [TestCaseSource(nameof(Sets))]
        public void CopyTo(ICollection<int> set)
        {
            int[] array = new int[500_000];
            set.CopyTo(array, 5000);
            Assert.That(array, Is.EquivalentTo(Enumerable.Repeat(0, 5000)
                .Concat(Enumerable.Range(0, 100_000))
                .Concat(Enumerable.Repeat(0, 500_000 - 100_000 - 5000))));
        }

        [TestCaseSource(nameof(Sets))]
        public void Clear(ICollection<int> set)
        {
        }

        [TestCaseSource(nameof(Sets))]
        public void Enumerate(ICollection<int> set)
        {
            
        }

        [TestCaseSource(nameof(Sets))]
        public void CheckCount(ICollection<int> set)
        {
        }

        [TestCaseSource(nameof(Sets))]
        public void Equals(ICollection<int> set)
        {
        }

        [TestCaseSource(nameof(Sets))]
        public void Clone(ICollection<int> set)
        {
        }

        [TestCaseSource(nameof(Sets))]
        public void ShallowCopy(ICollection<int> set)
        {
        }
    }
}