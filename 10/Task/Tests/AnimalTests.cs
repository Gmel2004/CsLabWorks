using Task;

namespace Tests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void TestEx()
        {
            Animal animal = new Animal();
            Assert.ThrowsException<ArgumentException>(() => animal.Name = "");
            Assert.ThrowsException<ArgumentException>(() => animal.Age = -1);
            Assert.ThrowsException<ArgumentException>(() => animal.Weight = -1);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Animal animal1 = new("Jack", 18, 42);
            Animal animal = (Animal)animal1.Clone();

            Assert.AreEqual("Jack", animal.Name);
            Assert.AreEqual(18, animal.Age);
            Assert.AreEqual(42, animal.Weight);
        }

        [TestMethod]
        public void TestEquals()
        {
            Animal animal1 = new("Jack", 18, 42);
            Animal animal2 = new("Jack", 18, 42);

            Assert.IsTrue(animal1.Equals(animal2));
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Animal animal1 = new("Jack", 18, 42);
            Animal animal2 = new("Jack", 18, 42);

            Assert.AreEqual(0, animal1.CompareTo(animal2));
        }

        [TestMethod]
        public void TestToString()
        {
            Animal animal = new("Jack", 18, 42);
            Assert.AreEqual("Jack:\n18 y. o.\n42 kg", animal.ToString());
        }
    }
}