using static _2.Program;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsBelongTrue()
        {
            Assert.AreEqual(true, BelongsToArea(0, 0));
        }

        [TestMethod]
        public void TestIsBelongFalse()
        {
            Assert.AreEqual(false, BelongsToArea(1, 1));
        }
    }
}