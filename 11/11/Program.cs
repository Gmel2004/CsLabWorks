namespace _11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TestCollections testCollections = new(1000);
            Console.WriteLine("Инициализация завершена!\n");
            testCollections.MeasureSearchTime();
        }
    }
}