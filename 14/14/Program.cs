using Task;

namespace _14
{
    internal class Program
    {
        enum typeAnimalsCounts
        {
            few,
            normal,
            many
        }

        static void Main(string[] args)
        {
            Dictionary<string, Queue<Animal>> collection = CreateDictionary();

            WriteDictionary(collection);

            Console.WriteLine("\t\tВыборка данных");
            WriteDictionary(collection
                .Where(t => t.Value.Count() > 3)
                .ToDictionary());
            //var f = (from t in collection
            //where t.Value.Count() > 3
            //select t);

            Console.WriteLine("\t\tПолучение счётчика");
            Console.WriteLine(collection.
                Where(t => t.Value.Count() > 3)
                .Sum(t => t.Value.Count));
            //var f = (from c in collection
            //where c.Value.Count() > 3
            //select c.Value.Count()).Sum(t => t);

            Console.WriteLine("\t\tИспользование операций над множествами");
            WriteDictionary(collection.Except(collection.
                Where(t => t.Value.Count() > collection.
                Average(x => x.Value.Count()))).ToDictionary());
            //var f = collection.Except(
            //    from t in collection
            //    where t.Value.Count() > collection.
            //    Average(x => x.Value.Count()) select t).
            //    ToDictionary();

            Console.WriteLine("\t\tАгрегация данных");
            Console.WriteLine(collection.
                Select(t => t.Value.Select(x => x.Weight).
                Aggregate((a, b) => a + b)).Sum());
            //var f = (from t in collection
            //         select
            //         t.Value.Select(x => x.Weight)
            //         .Aggregate((a, b) => a + b)).Sum();

            Console.WriteLine("\t\tГруппировка данных");
            var grouped = collection.
                GroupBy(t => GetMarkOfAnimalsCount(t.Value.Count()));
            //var f = from t in collection group t by
            //        GetMarkOfAnimalsCount(t.Value.Count());

            foreach (var i in grouped)
            {
                Console.WriteLine($"\t\t{GetMarkOfAnimalsCount(i.First().Value.Count())}:");
                foreach (var j in i)
                {
                    Console.WriteLine($"\tZoo {j.Key}:");
                    Console.WriteLine(string.Join("\n\n", j.Value));
                    Console.WriteLine();
                }
            }
        }

        static Dictionary<string, Queue<Animal>> CreateDictionary()
        {
            Dictionary<string, Queue<Animal>> collection = [];
            Random rnd = new Random();
            for (int i = rnd.Next(10); i < rnd.Next(11, 20); i++)
            {
                Queue<Animal> queue = [];
                for (int j = 1; j < rnd.Next(2, 20); j++)
                {
                    Animal animal = new Animal();
                    animal.InitRandom();
                    queue.Enqueue(animal);
                }
                string key = "";
                for (int j = 1; j < rnd.Next(2, 10); j++)
                {
                    key += (char)rnd.Next(255);
                }
                collection[key] = queue;
            }
            return collection;
        }

        static void WriteDictionary(Dictionary<string, Queue<Animal>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"\tZoo {item.Key}:");
                Console.WriteLine(string.Join("\n\n", item.Value));
                Console.WriteLine();
            }
        }

        static typeAnimalsCounts GetMarkOfAnimalsCount(int count)
        {
            if (count <= 3) return typeAnimalsCounts.few;
            if (count < 6) return typeAnimalsCounts.normal;
            return typeAnimalsCounts.many;
        }
    }
}
