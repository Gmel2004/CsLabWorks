<<<<<<< HEAD
﻿namespace Task
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
=======
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TestCollections testCollections = new(100000);
            Console.WriteLine("Инициализация завершена!\n");
            testCollections.MeasureSearchTime();
        }
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}