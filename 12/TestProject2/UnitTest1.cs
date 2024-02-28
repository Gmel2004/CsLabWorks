using _12;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Temp()
        {
            MySortedSet<int> first = new();
            MySortedSetExperemental<int> second = new();
            for (var i = 0; i < 10000; i++)
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

            for (var i = 0; i < 100; i++) first.Add(i);
            for (var i = 0; i < 100; i++) second.Add(i);
            Assert.AreEqual(first, new MySortedSet<int>(Enumerable.Range(0, 100)));
            Assert.AreEqual(second, new MySortedSetExperemental<int>(Enumerable.Range(0, 100)));
        }
    }
}