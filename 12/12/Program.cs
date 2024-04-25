using Task;

namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new();

            CreateAnimals<Bird>(animals);
            CreateAnimals<Artiodactyl>(animals);
            CreateAnimals<Mammal>(animals);

            Console.WriteLine("---Проход по List<Animal> animals:---");
            animals.ForEach(t => { t.InitRandom(); Console.WriteLine(t); Console.WriteLine(); });

            MySortedSet<Animal> first = new(animals);
            Console.WriteLine("---Проход по MySortedSet<Animal> firstMySortedSetForAnimals---");
            Console.WriteLine("(Использование встроенного компоратора - по типу и полям):");

            foreach (var item in first)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            MySortedSet<Animal> second = new(animals, new AnimalNameComparer());
            Console.WriteLine("---Проход по MySortedSet<Animal> secondMySortedSetForAnimals---");
            Console.WriteLine("(Использование внешнего компоратора - по имени):");

            foreach (var item in second)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("---Проверка содеражания---");
            Console.WriteLine("Животное:");
            Console.WriteLine(animals[animals.Count / 2].ToString());
            Console.WriteLine("1) firstMySortedSetForAnimals");
            Console.WriteLine($"Содержит:" +
                $"{first.Contains(animals[animals.Count / 2])}");
            Console.WriteLine();

            Console.WriteLine("2) secondMySortedSetForAnimals");
            Console.WriteLine($"Содержит:" +
                $"{second.Contains(animals[animals.Count / 2])}");
            Console.WriteLine();

            Console.WriteLine("---Проверка удаления---");
            Console.WriteLine("1) firstMySortedSetForAnimals");
            Console.WriteLine("Животное:");
            Console.WriteLine(animals[animals.Count / 2].ToString());
            first.Remove(animals[animals.Count / 2]);
            Console.WriteLine("---Проход:---");

            foreach (var item in first)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("2) secondMySortedSetForAnimals");
            second.Remove(animals[animals.Count / 2]);
            Console.WriteLine("---Проход:---");

            foreach (var item in second)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("---Проверка содеражания---");
            Console.WriteLine("Животное:");
            Console.WriteLine(animals[animals.Count / 2].ToString());
            Console.WriteLine("1) firstMySortedSetForAnimals");
            Console.WriteLine($"Содержит:" +
                $"{first.Contains(animals[animals.Count / 2])}");
            Console.WriteLine();

            Console.WriteLine("2) secondMySortedSetForAnimals");
            Console.WriteLine($"Содержит:" +
                $"{second.Contains(animals[animals.Count / 2])}");
            Console.WriteLine();

            Console.WriteLine("---Проверка копирования---");
            var bird = new Bird();
            bird.InitRandom();
            Console.WriteLine("1) Глубокое:");
            second = (MySortedSet<Animal>)first.Clone();
            first.Add(bird);
            Console.WriteLine($"""
                first.Count: {first.Count}
                second.Count: {second.Count}
                """);
            Console.WriteLine();
            Console.WriteLine("2) Поверхностное:");
            second = (MySortedSet<Animal>)first.ShallowCopy();
            first.Remove(bird);
            Console.WriteLine($"""
                first.Count: {first.Count}
                second.Count: {second.Count}
                """);
            Console.WriteLine();
        }

        private static void CreateAnimals<T>(List<Animal> animals) where T : Animal, new()
        {
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 5); i++)
            {
                animals.Add(new T());
            }
        }
    }
}