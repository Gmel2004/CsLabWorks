using Task;

namespace Tests
{
    [TestClass]
    public class AnimalWeightComparerTests
    {
        [TestMethod]
        public void TestCompare()
        {
            List<Animal> animals = new() { new Bird(), new Mammal()};
            animals[0].Weight = 15;
            animals[1].Weight = 80;

            animals.Sort(new AnimalWeightComparer());

            Assert.AreEqual(animals[0].Weight, 15);
        }
    }
}
