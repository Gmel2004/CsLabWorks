using static Banchmark.Banchmark;

namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<MySortedSetsBanchmarks>();
            Console.WriteLine($"TestMySortedSetAddLarge {MeasureTime(TestMySortedSetAddLarge)}");
            Console.WriteLine($"TestMyOtherSortedSetAddLarge {MeasureTime(TestMyOtherSortedSetAddLarge)}");
            Console.WriteLine($"TestMySortedSetAddSmall {MeasureTime(TestMySortedSetAddSmall)}");
            Console.WriteLine($"TestMyOtherSortedSetAddSmall {MeasureTime(TestMyOtherSortedSetAddSmall)}");
            Console.WriteLine($"TestMySortedSetRemoveLarge {MeasureTime(TestMySortedSetRemoveLarge)}");
            Console.WriteLine($"TestMyOtherSortedSetRemoveLarge {MeasureTime(TestMyOtherSortedSetRemoveLarge)}");
            Console.WriteLine($"TestMySortedSetRemoveSmall {MeasureTime(TestMySortedSetRemoveSmall)}");
            Console.WriteLine($"TestMyOtherSortedSetRemoveSmall {MeasureTime(TestMyOtherSortedSetRemoveSmall)}");
            Console.WriteLine($"TestMySortedSetCopyToLarge {MeasureTime(TestMySortedSetCopyToLarge)}");
            Console.WriteLine($"TestMyOtherSortedSetCopyToLarge {MeasureTime(TestMyOtherSortedSetCopyToLarge)}");
            Console.WriteLine($"TestMySortedSetCopyToSmall {MeasureTime(TestMySortedSetCopyToSmall)}");
            Console.WriteLine($"TestMyOtherSortedSetCopyToSmall {MeasureTime(TestMyOtherSortedSetCopyToSmall)}");
            Console.WriteLine($"TestMySortedSetContainsLarge {MeasureTime(TestMySortedSetContainsLarge)}");
            Console.WriteLine($"TestMyOtherSortedSetContainsLarge {MeasureTime(TestMyOtherSortedSetContainsLarge)}");
            Console.WriteLine($"TestMySortedSetContainsSmall {MeasureTime(TestMySortedSetContainsSmall)}");
            Console.WriteLine($"TestMyOtherSortedSetContainsSmall {MeasureTime(TestMyOtherSortedSetContainsSmall)}");
            Console.WriteLine($"TestMySortedSetClearLarge {MeasureTime(TestMySortedSetClearLarge)}");
            Console.WriteLine($"TestMyOtherSortedSetClearLarge {MeasureTime(TestMyOtherSortedSetClearLarge)}");
            Console.WriteLine($"TestMySortedSetClearSmall {MeasureTime(TestMySortedSetClearSmall)}");
            Console.WriteLine($"TestMyOtherSortedSetClearSmall {MeasureTime(TestMyOtherSortedSetClearSmall)}");


        }
        private static MySortedSet<int> GetMySortedSetAfterLargeClear()
        {
            MySortedSet<int> set = new();
            for (int i = 0; i < 10000; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 100; i++) set.Add(i);
            return set;
        }

        private static MyOtherSortedSet<int> GetMyOtherSortedSetAfterLargeClear()
        {
            MyOtherSortedSet<int> set = new();
            for (int i = 0; i < 10000; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 100; i++) set.Add(i);
            return set;
        }

        private static MySortedSet<int> GetMySortedSetAfterSmallClear()
        {
            MySortedSet<int> set = new();
            for (int i = 0; i < 100; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 10; i++) set.Add(i);
            return set;
        }

        private static MyOtherSortedSet<int> GetMyOtherSortedSetAfterSmallClear()
        {
            MyOtherSortedSet<int> set = new();
            for (int i = 0; i < 100; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 10; i++) set.Add(i);
            return set;
        }

        public static void TestMySortedSetAddLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            for (var i = 200; i < 300; i++)
            {
                set.Add(i);
            }
        }

        public static void TestMyOtherSortedSetAddLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            for (var i = 200; i < 300; i++)
            {
                set.Add(i);
            }
        }

        public static void TestMySortedSetAddSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            for (var i = 20; i < 30; i++)
            {
                set.Add(i);
            }
        }

        public static void TestMyOtherSortedSetAddSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            for (var i = 20; i < 30; i++)
            {
                set.Add(i);
            }
        }

        public static void TestMySortedSetRemoveLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Remove(314);
        }

        public static void TestMyOtherSortedSetRemoveLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Remove(314);
        }

        public static void TestMySortedSetRemoveSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Remove(314);
        }

        public static void TestMyOtherSortedSetRemoveSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Remove(314);
        }

        public static void TestMySortedSetCopyToLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        public static void TestMyOtherSortedSetCopyToLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        public static void TestMySortedSetCopyToSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        public static void TestMyOtherSortedSetCopyToSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        public static void TestMySortedSetContainsLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Contains(500);
        }

        public static void TestMyOtherSortedSetContainsLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Contains(500);
        }

        public static void TestMySortedSetContainsSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Contains(500);
        }

        public static void TestMyOtherSortedSetContainsSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Contains(500);
        }

        public static void TestMySortedSetClearLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Clear();
        }

        public static void TestMyOtherSortedSetClearLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Clear();
        }

        public static void TestMySortedSetClearSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Clear();
        }

        public static void TestMyOtherSortedSetClearSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Clear();
        }
    }
}