using Task;

namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SortedSet<sbyte>
            List<Animal> animals = new();

            CreateAnimals<Bird>(animals);
            CreateAnimals<Artiodactyl>(animals);
            CreateAnimals<Mammal>(animals);

            Console.WriteLine("---Проход по List<Animal> animals:---");
            animals.ForEach(t => { t.InitRandom(); Console.WriteLine(t); Console.WriteLine(); });

            MySortedSet<Animal> firstMySortedSetForAnimals = new(animals);
            Console.WriteLine("---Проход по MySortedSet<Animal> firstMySortedSetForAnimals---");
            Console.WriteLine("(Использование встроенного компоратора - по имени):");

            foreach (var item in firstMySortedSetForAnimals)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            MySortedSet<Animal> secondMySortedSetForAnimals = new(animals, new AnimalWeightComparer());
            Console.WriteLine("---Проход по MySortedSet<Animal> secondMySortedSetForAnimals---");
            Console.WriteLine("(Использование внешнего компоратора - по весу):");

            foreach (var item in secondMySortedSetForAnimals)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("---Проверка поиска---");
            Console.WriteLine("1) firstMySortedSetForAnimals");
            var node = firstMySortedSetForAnimals.FindNode(animals[2]);
            Console.WriteLine("Значение:");
            Console.WriteLine(node!.Value);
            Console.WriteLine();

            Console.WriteLine("2) secondMySortedSetForAnimals");
            node = secondMySortedSetForAnimals.FindNode(animals[2]);
            Console.WriteLine("Значение:");
            Console.WriteLine(node!.Value);
            Console.WriteLine();

            Console.WriteLine("---Проверка удаления---");
            Console.WriteLine("1) firstMySortedSetForAnimals");
            firstMySortedSetForAnimals.Remove(animals[2]);
            Console.WriteLine("---Проход:---");

            foreach (var item in firstMySortedSetForAnimals)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("2) secondMySortedSetForAnimals");
            secondMySortedSetForAnimals.Remove(animals[2]);
            Console.WriteLine("---Проход:---");

            foreach (var item in secondMySortedSetForAnimals)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
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
