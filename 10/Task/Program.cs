<<<<<<< HEAD
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
=======
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
        {
            List<Animal> animals = new();

            CreateAnimals<Bird>(animals);
            CreateAnimals<Artiodactyl>(animals);
            CreateAnimals<Mammal>(animals);

            Console.WriteLine("---РАБОТА С LIST<ANIMAL>:---");
            animals.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });
            Console.WriteLine();

            Console.WriteLine("---ЗАПРОСЫ:---");
<<<<<<< HEAD
            //Средний вес птиц
=======
            //Средний вес животных заданного вида
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
            Console.WriteLine(animals.Where(x => x is Bird)
                .DefaultIfEmpty(new Bird())
                .Average(x => x.Weight));
            Console.WriteLine();

            //Наименование птиц
            Console.WriteLine(string.Join("\n", animals.Where(x => x is Bird)
                .Select(x => x.Name).DefaultIfEmpty("None")));
            Console.WriteLine();

            //Средний возвраст парнокопытных из подотряда Suina
<<<<<<< HEAD
            Console.WriteLine(animals.Where(x => x is Artiodactyl artiodactyl
=======
            Console.WriteLine(animals.Where(x => x is Artiodactyl artiodactyl
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
            && artiodactyl.Suborder == Artiodactyl.ArtiodactylSuborder.Suina)
                .DefaultIfEmpty(new Artiodactyl()).Average(x => x.Age));
            Console.WriteLine();

            Console.WriteLine("---СОРТИРОВКА:---");
<<<<<<< HEAD

            Console.WriteLine("\t---Внешний компаратор:---");
            animals.Sort(new AnimalWeightComparer());
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("\t---Реализованный компаратор:---");
            animals.Sort();
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("---БИНАРНЫЙ ПОИСК:---");
            Animal animal = new()
            {
                Name = animals[animals.Count / 2].Name
            };
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
            List<IInit> inits = new() { new Stone(), new Artiodactyl(), new Bird(), new Mammal() };
=======
            Console.WriteLine("1)");
            animals.Sort();
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("2)");
            animals.Sort(new AnimalWeightComparer());
            animals.ForEach(x => { x.Show(); Console.WriteLine(); });

            Console.WriteLine("---РАБОТА С LIST<IINIT>:---");
            List<IInit> inits = new List<IInit> { new Stone(), new Artiodactyl(), new Bird(), new Mammal() };
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
            inits.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });

            Console.WriteLine("---КОПИРОВАНИЕ:---");
            Stone oleg = new();
            oleg.InitRandom();

            Stone igor = (Stone)oleg.Clone();

            Stone sergey = (Stone)oleg.ShallowCopy();

<<<<<<< HEAD
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
=======
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
            for (int i = 0; i < rnd.Next(0, 5); i++)
            {
                animals.Add(new T());
            }
        }
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}