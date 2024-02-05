namespace _12
{
    [TestClass]
    public class MySortedSetTests
    {
        [TestMethod]
        public void AddElementsToSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int>();
            set.Add(3);
            set.Add(1);
            set.Add(5);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void RemoveElementFromSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            set.Remove(3);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 5 }));
        }

        [TestMethod]
        public void ClearSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ContainsElementInSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };

            Assert.IsTrue(set.Contains(3));
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod]
        public void CopyToArray()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void Enumeration()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void EqualityComparison()
        {
            MySortedSet<int> set1 = new MySortedSet<int> { 3, 1, 5 };
            MySortedSet<int> set2 = new MySortedSet<int> { 1, 3, 5 };

            Assert.IsTrue(set1.Equals(set2));
        }
    }
}