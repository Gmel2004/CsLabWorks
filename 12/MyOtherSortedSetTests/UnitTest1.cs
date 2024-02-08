namespace _12
{
    [TestClass]
    public class MyOtherSortedSetTests
    {
        #region Basic Operations

        [TestMethod]
        public void AddElementsToSortedSet()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int>();
            set.Add(3);
            set.Add(1);
            set.Add(5);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void RemoveElementFromSortedSet()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            set.Remove(3);

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 5 }));
        }

        [TestMethod]
        public void ClearSortedSet()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ContainsElementInSortedSet()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };

            Assert.IsTrue(set.Contains(3));
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod]
        public void CopyToArray()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CopyToFullArray()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CopyToPartialArray()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            int[] array = new int[5] { 0, 0, 0, 0, 0 };
            set.CopyTo(array, 1);

            Assert.IsTrue(array.SequenceEqual(new[] { 0, 1, 3, 5, 0 }));
        }

        [TestMethod]
        public void CopyToWithStartIndex()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };
            int[] array = new int[5];
            set.CopyTo(array, 2);

            Assert.IsTrue(array.SequenceEqual(new[] { 0, 0, 1, 3, 5 }));
        }

        [TestMethod]
        public void Enumeration()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int> { 3, 1, 5 };

            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void EqualityComparison()
        {
            MyOtherSortedSet<int> set1 = new MyOtherSortedSet<int> { 3, 1, 5 };
            MyOtherSortedSet<int> set2 = new MyOtherSortedSet<int> { 1, 3, 5 };

            Assert.AreEqual(set1, set2);
        }

        #endregion

        #region String Operations

        [TestMethod]
        public void AddStringElementsToSortedSet()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string>();
            set.Add("apple");
            set.Add("banana");
            set.Add("orange");

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        [TestMethod]
        public void RemoveStringElementFromSortedSet()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string> { "apple", "banana", "orange" };
            set.Remove("banana");

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "orange" }));
        }

        [TestMethod]
        public void ClearStringSortedSet()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string> { "apple", "banana", "orange" };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<string>()));
        }

        [TestMethod]
        public void ContainsStringElementInSortedSet()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string> { "apple", "banana", "orange" };

            Assert.IsTrue(set.Contains("banana"));
            Assert.IsFalse(set.Contains("grape"));
        }

        [TestMethod]
        public void CopyToStringArray()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string> { "apple", "banana", "orange" };
            string[] array = new string[3];
            set.CopyTo(array, 0);

            Assert.IsTrue(array.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        [TestMethod]
        public void EnumerationOfStringSet()
        {
            MyOtherSortedSet<string> set = new MyOtherSortedSet<string> { "apple", "banana", "orange" };

            Assert.IsTrue(set.SequenceEqual(new[] { "apple", "banana", "orange" }));
        }

        #endregion

        #region Constructor Operations

        [TestMethod]
        public void DefaultConstructor()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int>();
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void ComparerConstructor()
        {
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int>(Comparer<int>.Default);
            Assert.AreEqual(0, set.Count);
            Assert.IsTrue(set.SequenceEqual(Enumerable.Empty<int>()));
        }

        [TestMethod]
        public void CollectionConstructor()
        {
            MyOtherSortedSet<int> sourceSet = new MyOtherSortedSet<int> { 3, 1, 5 };
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int>(sourceSet);
            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        [TestMethod]
        public void CollectionAndComparerConstructor()
        {
            MyOtherSortedSet<int> sourceSet = new MyOtherSortedSet<int> { 3, 1, 5 };
            MyOtherSortedSet<int> set = new MyOtherSortedSet<int>(sourceSet, Comparer<int>.Default);
            Assert.AreEqual(3, set.Count);
            Assert.IsTrue(set.SequenceEqual(new[] { 1, 3, 5 }));
        }

        #endregion
    }
}
