using static _1.Program;

namespace Tests1
{
    [TestClass]
    public class UnitTestNM
    {
        [TestMethod]
        public void TestFirst()
        {
            Assert.AreEqual((12, 4, 4), DoFirstActionWithNM(3, 4));
        }

        [TestMethod]
        public void TestSecond()
        {
            Assert.AreEqual((true, 15, 13), DoSecondActionWithNM(15, 14));
        }

        [TestMethod]
        public void TestThird()
        {
            Assert.AreEqual((false, 8, 8), DoThirdActionWithNM(8, 7));
        }
    }

    [TestClass]
    public class UnitTestX
    {
        [TestMethod]
        public void TestEx()
        {
            Assert.ThrowsException<Exception>(() => CalculateTheValue(-8));
        }

        [TestMethod]
        public void TestCorrect()
        {
            Assert.AreEqual(1, CalculateTheValue(-1));
        }
    }
}