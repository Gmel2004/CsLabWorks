using _12;
using Task;

namespace _14
{
    public static class MySortedSetExtensios
    {
        public static IEnumerable<Animal> Where<Tvalue>(MySortedSet<Animal> collection, Func<Animal, bool> predicate)
        {
            return collection.Where(predicate);
        }

        public static IEnumerable<Animal> OrderBy(MySortedSet<Animal> collection, Func<Animal, bool> predicate)
        {
            return collection.OrderBy(predicate);
        }

        public static IEnumerable<Animal> OrderByDescending(MySortedSet<Animal> collection, Func<Animal, bool> predicate)
        {
            return collection.OrderByDescending(predicate);
        }

        public static double Average<Animal>(MySortedSet<Animal> collection, Func<Animal, double> predicate)
        {
            return collection.Average(predicate);
        }

        public static int Count(MySortedSet<Animal> collection)
        {
            return collection.Count;
        }

        public static int Count(MySortedSet<Animal> collection, Func<Animal, bool> predicate)
        {
            return collection.Where(predicate).Count();
        }
    }
}
