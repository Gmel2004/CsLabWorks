using Task;

namespace _13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyNewCollection collection1 = new MyNewCollection("Collection1");
            MyNewCollection collection2 = new MyNewCollection("Collection2");

            collection1.OnItemAdded += collection1.RememberChanges;
            collection2.OnItemRemoved += collection2.RememberChanges;

            collection1.Add(new Bird("Kasha", 2, 2, 0.2));
            collection1.Add(new Animal("Den", 20, 23));
            collection1.Remove(collection1.First()); // Запись в журнал не добавится

            collection2.Add(new Animal("Jack", 13, 33)); // Запись в журнал не добавится
            collection2.Add(new Artiodactyl("Ant", 12, 40, Artiodactyl.ArtiodactylSuborder.Tylopoda)); // Запись в журнал не добавится
            collection2.Remove(collection2.Last());

            Console.WriteLine(MyNewCollection.Changes);
        }
    }
}
