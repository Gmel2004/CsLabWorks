namespace Task
{
    public class AnimalNameComparer : IComparer<Animal>
    {
        public int Compare(Animal? x, Animal? y)
        {
            if (x == null && y == null) return 0;
            if (y == null) return 1;
            if (x == null) return -1;
            return x.Name.CompareTo(y.Name);
        }
    }
}
