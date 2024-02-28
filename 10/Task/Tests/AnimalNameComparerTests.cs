using Task;

namespace Tests
{
    [TestClass]
    public class AnimalNameComparerTests
    {
        [TestMethod]
        public void TestCompare()
        {
            AnimalNameComparer comparer = new();
            List<Animal> animals = new() { new Bird(), new Mammal(), null!, null!};
            animals[0].Name = "Oleg";
            animals[1].Name = "Ben";

            Assert.AreEqual(0, comparer.Compare(animals[2], animals[3]));
            Assert.AreEqual(1, comparer.Compare(animals[0], animals[3]));
            Assert.AreEqual(-1, comparer.Compare(animals[3], animals[1]));
            Assert.AreEqual(1, comparer.Compare(animals[0], animals[1]));
        }
    }
}
