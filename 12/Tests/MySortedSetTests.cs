using _12;

namespace Tests
{
    [TestFixture(typeof(MySortedSet<int>))]
    [TestFixture(typeof(MySortedSetExperemental<int>))]
    public class MySortedSetTests<TCollection> where TCollection : ICollection<int>, ICloneable, new()
    {
        private const int elementsCount = 10000;
        private static ICollection<int> set;

        [SetUp]
        public void SetUp()
        {
            if (set is not null && set.Count == elementsCount) return;

            set = new TCollection();
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
            var duplicate = GetDuplicate(set, false);
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

        [Test]
        public void ShallowCopy()
        {
            var duplicate = GetDuplicate(set, true);
            set.Remove(77);
            Assert.That(set, Is.EqualTo(duplicate));
        }

        private ICollection<int> GetDuplicate(ICollection<int> set, bool isShallowCopy) => set switch
        {
            MySortedSet<int> mySet
                => (ICollection<int>)(isShallowCopy ? mySet.ShallowCopy() : mySet.Clone()),
            MySortedSetExperemental<int> mySetExperemental
                => (ICollection<int>)(isShallowCopy ? mySetExperemental.ShallowCopy() : mySetExperemental.Clone()),
            _ => throw new NotImplementedException()
        };
    }
}