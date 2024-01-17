using Task;
using System.Diagnostics;

namespace _11
{
    public class TestCollections
    {
        public List<Mammal> col1 = new();
        public List<string> col2 = new();
        public Dictionary<Animal, Mammal> col3 = new();
        public Dictionary<string, Mammal> col4 = new();

        public TestCollections(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Mammal mammal = new();
                mammal.InitRandom();
                col1.Add(mammal);
                col2.Add(mammal.ToString());
                col3[mammal.BaseAnimal] = mammal;
                col4[mammal.ToString()] = mammal;
            }
        }

        public void MeasureSearchTime()
        {
            Mammal notIncoming = new();
            notIncoming.InitRandom();
            notIncoming.Name = "rrrturr8";

            WriteTime(
                "col1",
                () => col1.Contains(new Mammal(col1[0])),
                () => col1.Contains(new Mammal(col1[col1.Count / 2])),
                () => col1.Contains(new Mammal(col1[^1])),
                () => col1.Contains(notIncoming));

            WriteTime(
                "col2",
                () => col2.Contains(col2[0].ToString()),
                () => col2.Contains(col2[col2.Count / 2].ToString()),
                () => col2.Contains(col2[^1].ToString()),
                () => col2.Contains("rrrtrrr"));

            WriteTime(
                "col3.ContainsKey",
                () => col3.ContainsKey(new Animal(col3.Keys.First())),
                () => col3.ContainsKey(new Animal(col3.Keys.ToArray()[col3.Count / 2])),
                () => col3.ContainsKey(new Animal(col3.Keys.Last())),
                () => col3.ContainsKey(notIncoming.BaseAnimal));

            WriteTime(
                "col3.ContainsValue",
                () => col3.ContainsValue(new Mammal(col3.Values.First())),
                () => col3.ContainsValue(new Mammal(col3.Values.ToArray()[col3.Count / 2])),
                () => col3.ContainsValue(new Mammal(col3.Values.Last())),
                () => col3.ContainsValue(notIncoming));

            WriteTime(
                "col4.ContainsKey",
                () => col4.ContainsKey(col4.Keys.First().ToString()),
                () => col4.ContainsKey(col4.Keys.ToArray()[col4.Count / 2].ToString()),
                () => col4.ContainsKey(col4.Keys.Last().ToString()),
                () => col4.ContainsKey(notIncoming.ToString()));

            WriteTime(
                "col4.ContainsValue",
                () => col4.ContainsValue(new Mammal(col4.Values.First())),
                () => col4.ContainsValue(new Mammal(col4.Values.ToArray()[col4.Count / 2])),
                () => col4.ContainsValue(new Mammal(col4.Values.Last())),
                () => col4.ContainsValue(notIncoming));
        }

        public static void WriteTime(string name, Action first, Action middle, Action last, Action notIncoming)
        {
            Console.WriteLine($"{name}:\n\tfirst: {MeasureTime(first)}\t" +
                $"middle: {MeasureTime(middle)}\t" +
                $"last: {MeasureTime(last)}\t" +
                $"not incoming: {MeasureTime(notIncoming)}\n");
        }

        public static double MeasureTime(Action action)
        {
            var sw = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                action();
            }
            int n = 100;
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                action();
            }
            sw.Stop();
            return sw.Elapsed.Ticks / n;
        }
    }
}