using BenchmarkDotNet.Attributes;

namespace _12
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MySortedSetsBanchmarks
    {
        private MySortedSet<int> GetMySortedSetAfterLargeClear()
        {
            MySortedSet<int> set = new();
            for (int i = 0; i < 10000; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 100; i++) set.Add(i);
            return set;
        }

        private MyOtherSortedSet<int> GetMyOtherSortedSetAfterLargeClear()
        {
            MyOtherSortedSet<int> set = new();
            for (int i = 0; i < 10000; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 100; i++) set.Add(i);
            return set;
        }

        private MySortedSet<int> GetMySortedSetAfterSmallClear()
        {
            MySortedSet<int> set = new();
            for (int i = 0; i < 100; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 10; i++) set.Add(i);
            return set;
        }

        private MyOtherSortedSet<int> GetMyOtherSortedSetAfterSmallClear()
        {
            MyOtherSortedSet<int> set = new();
            for (int i = 0; i < 100; i++) set.Add(i);
            set.Clear();
            for (int i = 0; i < 10; i++) set.Add(i);
            return set;
        }

        [Benchmark]
        public void TestMySortedSetAddLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            for (var i = 200; i < 300; i++)
            {
                set.Add(i);
            }
        }

        [Benchmark]
        public void TestMyOtherSortedSetAddLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            for (var i = 200; i < 300; i++)
            {
                set.Add(i);
            }
        }

        [Benchmark]
        public void TestMySortedSetAddSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            for (var i = 20; i < 30; i++)
            {
                set.Add(i);
            }
        }

        [Benchmark]
        public void TestMyOtherSortedSetAddSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            for (var i = 20; i < 30; i++)
            {
                set.Add(i);
            }
        }

        [Benchmark]
        public void TestMySortedSetRemoveLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Remove(314);
        }

        [Benchmark]
        public void TestMyOtherSortedSetRemoveLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Remove(314);
        }

        [Benchmark]
        public void TestMySortedSetRemoveSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Remove(314);
        }

        [Benchmark]
        public void TestMyOtherSortedSetRemoveSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Remove(314);
        }

        [Benchmark]
        public void TestMySortedSetCopyToLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        [Benchmark]
        public void TestMyOtherSortedSetCopyToLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        [Benchmark]
        public void TestMySortedSetCopyToSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        [Benchmark]
        public void TestMyOtherSortedSetCopyToSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            int[] array = new int[1000];
            set.CopyTo(array, 500);
        }

        [Benchmark]
        public void TestMySortedSetContainsLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Contains(500);
        }

        [Benchmark]
        public void TestMyOtherSortedSetContainsLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Contains(500);
        }

        [Benchmark]
        public void TestMySortedSetContainsSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Contains(500);
        }

        [Benchmark]
        public void TestMyOtherSortedSetContainsSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Contains(500);
        }

        [Benchmark]
        public void TestMySortedSetClearLarge()
        {
            var set = GetMySortedSetAfterLargeClear();
            set.Clear();
        }

        [Benchmark]
        public void TestMyOtherSortedSetClearLarge()
        {
            var set = GetMyOtherSortedSetAfterLargeClear();
            set.Clear();
        }

        [Benchmark]
        public void TestMySortedSetClearSmall()
        {
            var set = GetMySortedSetAfterSmallClear();
            set.Clear();
        }

        [Benchmark]
        public void TestMyOtherSortedSetClearSmall()
        {
            var set = GetMyOtherSortedSetAfterSmallClear();
            set.Clear();
        }
    }
}