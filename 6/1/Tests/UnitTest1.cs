using static _1.Program;

namespace Tests1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            char[] array = "he11o world!".ToCharArray();
            RemoveAllDigits(ref array);
            Assert.AreEqual("heo world!", string.Join("", array));
        }

        [TestMethod]
        public void TestMethod2()
        {
            char[] array = "hello world!".ToCharArray();
            RemoveAllDigits(ref array);
            Assert.AreEqual("hello world!", string.Join("", array));
        }

        [TestMethod]
        public void TestMethod3()
        {
            char[] array = "never 2 late!".ToCharArray();
            RemoveAllDigits(ref array);
            Assert.AreEqual("never  late!", string.Join("", array));
        }

        [TestMethod]
        public void TestMethod4()
        {
            char[] array = new char[0];
            RemoveAllDigits(ref array);
            Assert.AreEqual(0, array.Length);
        }
    }
}