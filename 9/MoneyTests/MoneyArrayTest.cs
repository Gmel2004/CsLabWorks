using _9;

namespace MoneyArrayTest
{
    [TestClass]
    public class CheckConstructor
    {
        [TestMethod]
        public void ExNegativeCount()
        {
            Assert.ThrowsException<ArgumentException>(() => { MoneyArray arr = new(-3, true); });
        }

        [TestMethod]
        public void TestBaseConstructor()
        {
            Assert.AreEqual(new MoneyArray().GetArray().Length, 0);
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            MoneyArray arr1 = new(3, true);
            MoneyArray arr2 = new(arr1);

            Assert.AreEqual(arr1, arr2);
        }
    }

    [TestClass]
    public class TestFillArray
    {
        [TestMethod]
        public void ExOutOfRange()
        {
            Assert.ThrowsException<ArgumentException>(() => new MoneyArray().FillArray(1, 0, true));
        }

        [TestMethod]
        public void TestEqual()
        {
            MoneyArray arr = new(3, true);

            Money first = arr[0];
            arr.FillArray(1, 2, true);

            Assert.AreEqual(first, arr[0]);
        }
    }

    [TestClass]
    public class TestArithmeticMean
    {
        [TestMethod]
        public void ExIsEmpty()
        {
            Assert.ThrowsException<Exception>(() => new MoneyArray().GetArithmeticMean());
        }

        [TestMethod]
        public void TestEqual()
        {
            MoneyArray arr = new(3, true);
            arr[0] = new(1, 2);
            arr[1] = new(2, 3);
            arr[2] = new(3, 4);

            Assert.AreEqual(arr.GetArithmeticMean(), new Money(2, 3));
        }
    }

    [TestClass]
    public class TestOtherMetods
    {
        [TestMethod]
        public void TestInd()
        {
            MoneyArray arr = new(1, true);
            Money money1 = arr[0];
            Assert.AreEqual(money1, arr[0]);

            Money money2 = money1 + 1;
            arr[0] = money2;
            Assert.AreEqual(money2, arr[0]);
        }

        [TestMethod]
        public void TestResize()
        {
            MoneyArray arr = new(9, true);
            arr.Resize(4);
            Assert.AreEqual(arr.GetArray().Length, 4);
        }
    }
}
