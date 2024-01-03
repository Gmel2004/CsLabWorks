using Task;

namespace Tests
{
    [TestClass]
    public class BirdTests
    {
        [TestMethod]
        public void TestWingspanEx()
        {
            Bird bird = new Bird();

            Assert.ThrowsException<ArgumentException>(() => bird.Wingspan = -1);
        }

        [TestMethod]
        public void TestUseEquals()
        {
            Bird bird1 = new Bird();
            Bird bird2 = new Bird();

            Assert.AreEqual(bird1, bird2);
        }

        [TestMethod]
        public void TestEqualsTrue()
        {
            Bird bird = new Bird();
            bird.Wingspan = 1;

            Bird bird2 = new Bird();
            bird2.Wingspan = 1;

            Assert.IsTrue(bird.Equals(bird2));
        }

        [TestMethod]
        public void TestEqualsFalse()
        {
            Bird bird = new Bird();
            bird.Wingspan = 1;

            Bird bird2 = new Bird();

            Assert.IsFalse(bird.Equals(bird2));
        }

        [TestMethod]
        public void TestWingspan()
        {
            Bird bird = new();
            bird.Wingspan = 1;

            Assert.AreEqual(1, bird.Wingspan);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Bird bird1 = new("Jack", 13, 12, 1);
            Bird bird = (Bird)bird1.Clone();

            Assert.AreEqual("Jack", bird.Name);
            Assert.AreEqual(13, bird.Age);
            Assert.AreEqual(12, bird.Weight);
            Assert.AreEqual(1, bird.Wingspan);
        }
    }
}