using _9;

namespace MoneyTests
{
    [TestClass]
    public class CheckPriorities
    {
        [TestMethod]
        public void ExRubles()
        {
            Assert.ThrowsException<Exception>(() => new Money(-3, 4));
        }

        [TestMethod]
        public void ExKopeks()
        {
            Assert.ThrowsException<Exception>(() => new Money(3, -4));
        }

        [TestMethod]
        public void TestEqual()
        {
            Money money1 = new(3, 4);

            Money money2 = new(2, 104);

            Assert.AreEqual(money1, money2);
        }
    }

    [TestClass]
    public class CheckSubtractKopeks
    {
        [TestMethod]
        public void ExSubtractNegativeKopeks()
        {
            Assert.ThrowsException<Exception>(() => new Money(0, 0).SubtractKopeks(1));
        }

        [TestMethod]
        public void ExSubstractLargerSum()
        {
            Assert.ThrowsException<Exception>(() => new Money(2, 2).SubtractKopeks(203));
        }

        [TestMethod]
        public void TestEqual()
        {
            Money money1 = new(6, 65);
            Money money2 = new(7, 36);
            Assert.AreEqual(money1, money2.SubtractKopeks(71));
        }
    }

    [TestClass]
    public class CheckIsEmpty
    {
        [TestMethod]
        public void TestTrue()
        {
            Assert.IsTrue(new Money(0, 0).IsEmpty());
        }

        [TestMethod]
        public void TestFalse()
        {
            Assert.IsFalse(new Money(0, 1).IsEmpty());
        }
    }

    [TestClass]
    public class CheckBinaryOperations
    {
        [TestMethod]
        public void TestMinus()
        {
            Money money1 = new(134, 567);
            Money money2 = new(122, 433);

            Assert.AreEqual(money1 - money2, new Money(13, 34));
        }

        [TestMethod]
        public void TestMoneyPlusKopeks()
        {
            Money money1 = new(3, 99);
            Money money2 = new(6, 18);

            Assert.AreEqual(money1 + 219, money2);
        }
    }

    [TestClass]
    public class CheckUnaryOperations
    {
        [TestMethod]
        public void TestMinusMinus()
        {
            Money money = new(7, 0);
            Assert.AreEqual(--money, new Money(6, 99));
        }

        [TestMethod]
        public void TestPlusPlus()
        {
            Money money = new(7, 0);
            Assert.AreEqual(++money, new Money(7, 1));
        }

        [TestMethod]
        public void TestInt()
        {
            Assert.AreEqual((int)new Money(7, 45), 7);
        }

        [TestMethod]
        public void TestBool()
        {
            Assert.IsTrue(new Money(1, 0));
            Assert.IsFalse(new Money(0, 0));
        }

        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual(new Money(6, 53).ToString(), "Рубли: 6 копейки: 53");
        }
    }

    [TestClass]
    public class CheckOtherMethods
    {
        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(new Money(), new Money(0, 0));
        }

        [TestMethod]
        public void TestConvertToKopeks()
        {
            Money money = new(16, 3243);
            Assert.AreEqual(money.ConvertToKopeks(), 4843);
        }
    }
}