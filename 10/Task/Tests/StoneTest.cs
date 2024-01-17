using System.Drawing;
using Task;

namespace Tests
{
    [TestClass]
    public class StoneTests
    {
        [TestMethod]
        public void TestCountInCountries()
        {
            Stone oleg = new();
            oleg.CountInCountries["Russia"] = 99999;

            Assert.AreEqual(1, oleg.CountInCountries.Count);
        }

        [TestMethod]
        public void TestSkinColor()
        {
            Stone oleg = new();
            oleg.SkinColor = Color.White;

            Assert.AreEqual(oleg.SkinColor, Color.White);
        }

        [TestMethod]
        public void TestCloneAndEqualsTrue()
        {
            Stone oleg = new();
            oleg.SkinColor = Color.White;
            Stone igor = (Stone)oleg.Clone();

            Assert.IsTrue(igor.Equals(oleg));
        }

        [TestMethod]
        public void TestEqualsFalse()
        {
            Stone oleg = new();
            oleg.SkinColor = Color.White;
            Stone igor = new();

            Assert.IsFalse(igor.Equals(oleg));
        }

        [TestMethod]
        public void TestShallowCopy()
        {
            Stone oleg = new();
            oleg.CountInCountries["Russia"] = 9999;

            Stone igor = (Stone)oleg.ShallowCopy();
            oleg.CountInCountries["China"] = 1;
            Assert.IsTrue(igor.Equals(oleg));
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Stone oleg = new();
            oleg.SkinColor = Color.White;

            var expexted = "name = name\ncolor: Color [White]\nCountsInCountries:\n\t";
            var actual = oleg.ToString();
            var compaireRes = expexted.CompareTo(actual);

            Assert.AreEqual(0, compaireRes);
        }

        [TestMethod]
        public void TestName()
        {
            Stone stone = new();
            Assert.ThrowsException<ArgumentException>(() => stone.Name = "");
        }
    }
}