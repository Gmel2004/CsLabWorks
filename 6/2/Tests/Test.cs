using static _2.Program;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        [TestMethod]
        public void TestReverseAndSort()
        {
            var originalMessage = "���� ������; �����. ������: ����; �����. ����... �����; ����:";
            var expectedMessage = "���� ����; ������. ������: �����; �����. �����... ����; ����:";
            var lexion = SplitIntoTokens(originalMessage);

            Assert.AreEqual(expectedMessage, ReverseAndSort(lexion.Item1, lexion.Item2));
        }

        [TestMethod]
        public void TestSplitIntoTokensEndIsWord()
        {
            var originalMessage = "���� ������... ����! ���!? ����!? ���... ������: �����? ����";
            var lexion = SplitIntoTokens(originalMessage);
            var wordsString = string.Join(" ", lexion.Item1);
            var splitsString = string.Join("", lexion.Item2);
            var wordsStringExpexted = "���� ������ ���� ��� ���� ��� ������ ����� ����";
            var splitsStringExpected = " ... ! !? !? ... : ? ";

            Assert.AreEqual(wordsStringExpexted, wordsString);
            Assert.AreEqual(splitsStringExpected, splitsString);
        }

        [TestMethod]
        public void TestSplitIntoTokensEndIsSplit()
        {
            var originalMessage = "���� ������; �����. ������: ����; �����. ����... �����; ����:";
            var lexion = SplitIntoTokens(originalMessage);
            var wordsString = string.Join(" ", lexion.Item1);
            var splitsString = string.Join("", lexion.Item2);
            var wordsStringExpexted = "���� ������ ����� ������ ���� ����� ���� ����� ����";
            var splitsStringExpected = " ; . : ; . ... ; :";

            Assert.AreEqual(wordsStringExpexted, wordsString);
            Assert.AreEqual(splitsStringExpected, splitsString);
        }
    }

    [TestClass]
    public class TestOnEmpty
    {
        [TestMethod]
        public void TestReverseAndSort()
        {
            var originalMessage = "";
            var expectedMessage = "";
            var lexion = SplitIntoTokens(originalMessage);

            Assert.AreEqual(expectedMessage, ReverseAndSort(lexion.Item1, lexion.Item2));
        }

        [TestMethod]
        public void TestSplitIntoTokens()
        {
            var originalMessage = "";
            var lexion = SplitIntoTokens(originalMessage);
            var wordsString = string.Join(" ", lexion.Item1);
            var splitsString = string.Join("", lexion.Item2);
            var wordsStringExpexted = "";
            var splitsStringExpected = "";

            Assert.AreEqual(wordsStringExpexted, wordsString);
            Assert.AreEqual(splitsStringExpected, splitsString);
        }
    }
}