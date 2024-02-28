namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new();

            CreateAnimals<Bird>(animals);
            CreateAnimals<Artiodactyl>(animals);
            CreateAnimals<Mammal>(animals);

            Console.WriteLine("---РАБОТА С LIST<ANIMAL>:---");
            animals.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });
            Console.WriteLine();

            Console.WriteLine("---ЗАПРОСЫ:---");
            //Средний вес птиц
            Console.WriteLine(animals.Where(x => x is Bird)
                .DefaultIfEmpty(new Bird())
                .Average(x => x.Weight));
            Console.WriteLine();

            //Наименование птиц
            Console.WriteLine(string.Join("\n", animals.Where(x => x is Bird)
                .Select(x => x.Name).DefaultIfEmpty("None")));
            Console.WriteLine();

            //Средний возраст парнокопытных из подотряда Suina
            Console.WriteLine(animals.Where(x => x is Artiodactyl artiodactyl
            && artiodactyl.Suborder == Artiodactyl.ArtiodactylSuborder.Suina)
                .DefaultIfEmpty(new Artiodactyl()).Average(x => x.Age));
            Console.WriteLine();

            Console.WriteLine("---СОРТИРОВКА:---");

            Console.WriteLine("\t---Внешний компаратор---");
            Console.WriteLine("\tПо имени:");
            animals.Sort(new AnimalNameComparer());
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("\t---Реализованный компаратор---");
            Console.WriteLine("\tПо типу и полям:");
            animals.Sort();
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("---БИНАРНЫЙ ПОИСК:---");
            
            var animal = animals[animals.Count / 2];
            int indexOfSearch = animals.BinarySearch(animal);
            if (indexOfSearch > -1)
            {
                Console.WriteLine($"Животное по имени {animal.Name} " +
                    $"найдено в списке животных на {indexOfSearch + 1} позиции");
            }
            else
            {
                Console.WriteLine($"Животное по имени {animal.Name} не найдено в списке животных");
            }

            Console.WriteLine("---РАБОТА С LIST<IINIT>:---");
            List<IInit> inits = new List<IInit> { new Stone(), new Artiodactyl(), new Bird(), new Mammal() };

            inits.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });

            Console.WriteLine("---КОПИРОВАНИЕ:---");
            Stone oleg = new();
            oleg.InitRandom();

            Stone igor = (Stone)oleg.Clone();

            Stone sergey = (Stone)oleg.ShallowCopy();

            oleg.CountInCountries["Russia"] = 99999;

            Console.WriteLine(oleg);
            Console.WriteLine();
            Console.WriteLine(igor);
            Console.WriteLine();
            Console.WriteLine(sergey);
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