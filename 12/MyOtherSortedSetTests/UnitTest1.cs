namespace _12
{
    [TestClass]
    public class MyOtherSortedSetTests
    {
        #region Basic Operations

        [TestMethod]
        public void AddElementsToSortedSet()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int>();
            set.Add(3);
            set.Add(1);
            set.Add(5);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void RemoveElementFromSortedSet()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            set.Remove(3);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 5 }));
        }

        [TestMethod]
        public void ClearSortedSet()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ContainsElementInSortedSet()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };

            Assert.IsTrue(set.Contains(3));
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod]
        public void CopyToArray()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CopyToFullArray()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CopyToPartialArray()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            int[] array = new int[5] { 0, 0, 0, 0, 0 };
            set.CopyTo(array, 1);

            Assert.IsTrue(array.SequenceEqual(new[] { 0, 1, 3, 5, 0 }));
        }

        [TestMethod]
        public void CopyToWithStartIndex()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };
            int[] array = new int[5];
            set.CopyTo(array, 2);

            Assert.IsTrue(array.SequenceEqual(new[] { 0, 0, 1, 3, 5 }));
        }

        [TestMethod]
        public void Enumeration()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int> { 3, 1, 5 };

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void EqualityComparison()
        {
            MySortedSetExperemental<int> set1 = new MySortedSetExperemental<int> { 3, 1, 5 };
            MySortedSetExperemental<int> set2 = new MySortedSetExperemental<int> { 1, 3, 5 };

            Assert.AreEqual(set1, set2);
        }

        #endregion

        #region String Operations

        [TestMethod]
        public void AddStringElementsToSortedSet()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string>();
            set.Add("apple");
            set.Add("banana");
            set.Add("orange");

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        [TestMethod]
        public void RemoveStringElementFromSortedSet()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string> { "apple", "banana", "orange" };
            set.Remove("banana");

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "orange" }));
        }

        [TestMethod]
        public void ClearStringSortedSet()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string> { "apple", "banana", "orange" };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<string>()));
        }

        [TestMethod]
        public void ContainsStringElementInSortedSet()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string> { "apple", "banana", "orange" };

            Assert.IsTrue(set.Contains("banana"));
            Assert.IsFalse(set.Contains("grape"));
        }

        [TestMethod]
        public void CopyToStringArray()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string> { "apple", "banana", "orange" };
            string[] array = new string[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        [TestMethod]
        public void EnumerationOfStringSet()
        {
            MySortedSetExperemental<string> set = new MySortedSetExperemental<string> { "apple", "banana", "orange" };

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        #endregion

        #region Constructor Operations

        [TestMethod]
        public void DefaultConstructor()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int>();
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ComparerConstructor()
        {
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int>(Comparer<int>.Default);
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void CollectionConstructor()
        {
            MySortedSetExperemental<int> sourceSet = new MySortedSetExperemental<int> { 3, 1, 5 };
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int>(sourceSet);
            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CollectionAndComparerConstructor()
        {
            MySortedSetExperemental<int> sourceSet = new MySortedSetExperemental<int> { 3, 1, 5 };
            MySortedSetExperemental<int> set = new MySortedSetExperemental<int>(sourceSet, Comparer<int>.Default);
            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        #endregion
    }
}
