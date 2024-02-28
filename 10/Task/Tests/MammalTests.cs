using Task;

namespace Tests
{
    [TestClass]
    public class MammalTests
    {
        [TestMethod]
        public void TestSubclass()
        {
            Mammal mammal = new();
            mammal.Subclass = Mammal.MammalSubclass.Theria;

            Assert.AreEqual(Mammal.MammalSubclass.Theria, mammal.Subclass);
        }

        [TestMethod]
        public void TestName()
        {
            Mammal mammal = new();
            mammal.Name = "Jack";

            var animal = mammal.BaseAnimal;

            Assert.AreEqual(mammal.Name, animal.Name);
        }

        [TestMethod]
        public void TestToString()
        {
            Mammal mammal = new();

            Assert.AreEqual("standartName:\n0 y. o.\n1 kg\nMonotremes subclass", mammal.ToString());
        }

        [TestMethod]
        public void TestEqualsTrue()
        {
            Mammal mammal1 = new();
            Mammal mammal2 = new();

            Assert.IsTrue(mammal1.Equals(mammal2));
        }

        [TestMethod]
        public void TestCopy()
        {
            Mammal mammal1 = new("Jack", 14, 34, Mammal.MammalSubclass.Theria);
            Mammal mammal = (Mammal)mammal1.Clone();

            Assert.AreEqual("Jack", mammal.Name);
            Assert.AreEqual(14, mammal.Age);
            Assert.AreEqual(34, mammal.Weight);
            Assert.AreEqual(Mammal.MammalSubclass.Theria, mammal.Subclass);
        }
    }
}