using Task;

namespace Tests
{

    [TestClass]
    public class TestEquals
    {
        [TestMethod]
        public void TestUse()
        {
            Artiodactyl artiodactyl1 = new();
            Artiodactyl artiodactyl2 = new();

            artiodactyl1.Age = 16;
            artiodactyl2.Age = 16;

            Assert.AreEqual(artiodactyl2, artiodactyl1);
        }

        [TestMethod]
        public void TestTrue()
        {
            Artiodactyl artiodactyl1 = new();
            Artiodactyl artiodactyl2 = new();

            artiodactyl1.Age = 16;
            artiodactyl2.Age = 16;

            Assert.IsTrue(artiodactyl1.Equals(artiodactyl2));

        }

        [TestMethod]
        public void TestFalse()
        {
            Artiodactyl artiodactyl1 = new();
            Artiodactyl artiodactyl2 = new();

            artiodactyl1.Age = 16;

            Assert.IsFalse(artiodactyl1.Equals(artiodactyl2));
        }
    }

    [TestClass]
    public class OtherTests
    {
        [TestMethod]
        public void TestSuborder()
        {
            Artiodactyl artiodactyl = new();

            artiodactyl.Suborder = Artiodactyl.ArtiodactylSuborder.Suina;
            Assert.AreEqual(artiodactyl.Suborder, Artiodactyl.ArtiodactylSuborder.Suina);
        }

        [TestMethod]
        public void TestCopy()
        {
            Artiodactyl artiodactyl = new("Jack", 13, 45, Artiodactyl.ArtiodactylSuborder.Tylopoda);
            Artiodactyl artiodactyl1 = artiodactyl.Clone();

            Assert.AreEqual(artiodactyl, artiodactyl1);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Artiodactyl artiodactyl1 = new("Jack", 13, 45, Artiodactyl.ArtiodactylSuborder.Tylopoda);
            Artiodactyl artiodactyl = new(artiodactyl1);

            Assert.AreEqual("Jack", artiodactyl.Name);
            Assert.AreEqual(13, artiodactyl.Age);
            Assert.AreEqual(45, artiodactyl.Weight);
            Assert.AreEqual(Mammal.MammalSubclass.Theria, artiodactyl.Subclass);
            Assert.AreEqual(Artiodactyl.ArtiodactylSuborder.Tylopoda, artiodactyl.Suborder);
        }
    }
}