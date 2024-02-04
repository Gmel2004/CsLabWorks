using Task;

namespace _12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SortedSet<string> set = new SortedSet<string>();
            MySortedSet<Animal> Animals = new()
            {
                new Bird(), new Mammal(), new Artiodactyl(), new Animal()
            };

            foreach (var item in Animals)
            {
                item.InitRandom();
                Console.WriteLine(item.ToString());
            }

            //Animals.FindNode
        }
    }
}
