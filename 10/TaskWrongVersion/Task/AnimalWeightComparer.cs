namespace Task
{
    public class AnimalWeightComparer : IComparer<Animal>
    {
        public int Compare(Animal? x, Animal? y)
        {
            return x!.Weight.CompareTo(y!.Weight);
        }
    }
}
