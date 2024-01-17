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