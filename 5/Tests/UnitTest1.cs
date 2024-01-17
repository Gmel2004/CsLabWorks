using static _5.Program;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateOneArray()
        {
            var array = CreateOneArray(4);
            Assert.AreEqual(4, array.Length);
        }

        [TestMethod]
        public void TestCreateTwoArray()
        {
            var array = CreateTwoArray(4, 2);
            Assert.AreEqual((4, 2), (array.GetLength(0), array.GetLength(1)));
        }

        [TestMethod]
        public void TestDeleteRows()
        {
            int[,] array = new int[2, 4];
            DeleteRows(ref array, 0, 1);
            Assert.AreEqual(0, array.Length);
        }
    }
}