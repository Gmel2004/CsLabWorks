<<<<<<< HEAD
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal> { new Mammal(), new Bird(), new Bird(), new Mammal(), new Artiodactyl() };
            animals.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });
        }
    }
=======
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal> { new Mammal(), new Bird(), new Bird(), new Mammal(), new Artiodactyl() };
            animals.ForEach(x => { x.InitRandom(); x.Show(); Console.WriteLine(); });
        }
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}