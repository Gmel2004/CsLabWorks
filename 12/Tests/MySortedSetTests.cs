using _12;

namespace Tests
{
    [TestFixture(typeof(MySortedSet<int>))]
    [TestFixture(typeof(MySortedSetExperemental<int>))]
    public class MySortedSetTests<T> where T : ICollection<int>, ICloneable, new()
    {
        private const int elementsCount = 10000;
        private static T set;

        [SetUp]
        public void SetUp()
        {
            if (set is not null && set.Count == elementsCount) return;

            set = new T();
            for (var i = 0; i < 10000; i++)
            {
                set.Add(i);
            }
            set.Clear();
            for (var i = 0; i < elementsCount; i++)
            {
                set.Add(i);
            }
        }

        [Test]
        public void Add()
        {
            for (var i = 0; i < 1000; i++) set.Add(i);
            Assert.That(set, Is.EquivalentTo(Enumerable.Range(0, elementsCount)));
        }

        [Test]
        public void Contains()
        {
            Assert.That(set.Contains(100001), Is.False);
        }

        [Test]
        public void Remove()
        {
            Assert.That(set.Remove(77), Is.True);
        }

        [Test]
        public void CopyTo()
        {
            int[] array = new int[500000];
            set.CopyTo(array, 5000);
            Assert.That(array, Is.EquivalentTo(Enumerable.Repeat(0, 5000)
                .Concat(Enumerable.Range(0, elementsCount))
                .Concat(Enumerable.Repeat(0, 500000 - elementsCount - 5000))));
        }

        [Test]
        public void CheckCount()
        {
            Assert.That(set, Has.Count.EqualTo(elementsCount));
        }

        [Test]
        public void Clone()
        {
            var duplicate = set.Clone();
            set.Remove(77);
            Assert.That(set, Is.Not.EqualTo(duplicate));
        }

        [Test]
        public void Equals()
        {
            var duplicate = (ICollection<int>)((ICloneable)set).Clone();
            set.Remove(77);
            duplicate.Remove(77);
            Assert.That(set, Is.EqualTo(duplicate));
        }
    }
}