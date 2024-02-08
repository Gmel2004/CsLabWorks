using _12;

namespace MyNamespace.Tests
{
    [TestClass]
    public class MySortedSetTests
    {
        [TestMethod]
        public void AddElementsToSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
            }

            CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), set.ToArray());
        }

        [TestMethod]
        public void RemoveElementFromSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            set.Remove(3);

            CollectionAssert.AreEqual(new[] { 1, 5 }, set.ToArray());
        }

        [TestMethod]
        public void ClearSortedSet()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToArray(), set.ToArray());
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

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, array);
        }

        [TestMethod]
        public void CopyToFullArray()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            int[] array = new int[3];
            set.CopyTo(array, 0);

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, array);
        }

        [TestMethod]
        public void CopyToPartialArray()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            int[] array = new int[5] { 0, 0, 0, 0, 0 };
            set.CopyTo(array, 1);

            CollectionAssert.AreEqual(new[] { 0, 1, 3, 5, 0 }, array);
        }

        [TestMethod]
        public void CopyToWithStartIndex()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };
            int[] array = new int[5];
            set.CopyTo(array, 2);

            CollectionAssert.AreEqual(new[] { 0, 0, 1, 3, 5 }, array);
        }

        [TestMethod]
        public void Enumeration()
        {
            MySortedSet<int> set = new MySortedSet<int> { 3, 1, 5 };

            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, set.ToArray());
        }

        [TestMethod]
        public void EqualityComparison()
        {
            MySortedSet<int> set1 = new MySortedSet<int> { 3, 1, 5 };
            MySortedSet<int> set2 = new MySortedSet<int> { 1, 3, 5 };

            Assert.AreEqual(set1, set2);
        }

        [TestMethod]
        public void AddStringElementsToSortedSet()
        {
            MySortedSet<string> set = new MySortedSet<string>();
            set.Add("apple");
            set.Add("banana");
            set.Add("orange");

            CollectionAssert.AreEqual(new[] { "apple", "banana", "orange" }, set.ToArray());
        }

        [TestMethod]
        public void RemoveStringElementFromSortedSet()
        {
            MySortedSet<string> set = new MySortedSet<string> { "apple", "banana", "orange" };
            set.Remove("banana");

            CollectionAssert.AreEqual(new[] { "apple", "orange" }, set.ToArray());
        }

        [TestMethod]
        public void ClearStringSortedSet()
        {
            MySortedSet<string> set = new MySortedSet<string> { "apple", "banana", "orange" };
            set.Clear();

            Assert.AreEqual(0, set.Count);
            CollectionAssert.AreEqual(Enumerable.Empty<string>().ToArray(), set.ToArray());
        }

        [TestMethod]
        public void ContainsStringElementInSortedSet()
        {
            MySortedSet<string> set = new MySortedSet<string> { "apple", "banana", "orange" };

            Assert.IsTrue(set.Contains("banana"));
            Assert.IsFalse(set.Contains("grape"));
        }

        [TestMethod]
        public void CopyToStringArray()
        {
            MySortedSet<string> set = new MySortedSet<string> { "apple", "banana", "orange" };
            string[] array = new string[3];
            set.CopyTo(array, 0);

            CollectionAssert.AreEqual(new[] { "apple", "banana", "orange" }, array);
        }

        [TestMethod]
        public void EnumerationOfStringSet()
        {
            MySortedSet<string> set = new MySortedSet<string> { "apple", "banana", "orange" };

            CollectionAssert.AreEqual(new[] { "apple", "banana", "orange" }, set.ToArray());
        }

        [TestMethod]
        public void DefaultConstructor()
        {
            MySortedSet<int> set = new MySortedSet<int>();
            Assert.AreEqual(0, set.Count);
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToArray(), set.ToArray());
        }

        [TestMethod]
        public void ComparerConstructor()
        {
            MySortedSet<int> set = new MySortedSet<int>(Comparer<int>.Default);
            Assert.AreEqual(0, set.Count);
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToArray(), set.ToArray());
        }

        [TestMethod]
        public void CollectionConstructor()
        {
            MySortedSet<int> sourceSet = new MySortedSet<int> { 3, 1, 5 };
            MySortedSet<int> set = new MySortedSet<int>(sourceSet);
            Assert.AreEqual(3, set.Count);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, set.ToArray());
        }

        [TestMethod]
        public void CollectionAndComparerConstructor()
        {
            MySortedSet<int> sourceSet = new MySortedSet<int> { 3, 1, 5 };
            MySortedSet<int> set = new MySortedSet<int>(sourceSet, Comparer<int>.Default);
            Assert.AreEqual(3, set.Count);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, set.ToArray());
        }
    }
}
