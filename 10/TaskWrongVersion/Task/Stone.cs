using System.Drawing;
using static UserInput.CustomConsoleInput;

namespace Task
{
    public class Stone : IInit, ICloneable
    {
        private string name = "name";

        public SortedDictionary<string, int> CountInCountries { get; set; } = new();

        public string Name
        {
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException($"Ошибка! {nameof(Name)} не может являться пустой строкой!");
                }
                name = value;
            }
            get { return name!; }
        }

        public Color SkinColor { get; set; }

        public object Clone()
        {
            return new Stone() { Name = Name, SkinColor = SkinColor, CountInCountries = new SortedDictionary<string, int>(CountInCountries) };
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public void Init()
        {
            Name = ReadString("Введите название камня:", "Неверный ввод! Введите непустую строку:");
            SkinColor = ReadRGB();
            CountInCountries = new SortedDictionary<string, int> {};
            int ownCount = ReadInt("Введите количество:", "Неверный ввод! Введите целое неотрицательное число:", 0);
            for (int i = 0; i < ownCount; i++)
            {
                string country = ReadString("Введите название страны в которой находится камень:",
                    "Неверный ввод! Введите непустую строку:");
                int count = ReadInt("Введите количество:", "Неверный ввод! Введите целое неотрицательное число:", 0);
                CountInCountries[country] = count;
            }
        }

        public void InitRandom()
        {
            Random rnd = new Random();
            Name = GenarateRandomName(7);
            SkinColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            CountInCountries = new SortedDictionary<string, int> {};

            int ownCount = rnd.Next(0, 50);
            for (int i = 0; i < ownCount; i++)
            {
                string country = GenarateRandomName(7);
                int count = rnd.Next(0, 50);
                CountInCountries[country] = count;
            }
        }

        public override string ToString()
        {
            return $"name = {name}\ncolor: {SkinColor}\nCountsInCountries:\n\t{string.Join("\n\t", CountInCountries!)}";
        }

        private string GenarateRandomName(int maxLength)
        {
            if (maxLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Ошибка! Длина имени должна быть положительной");
            }
            Random rnd = new Random();
            return rnd.Next(65, 91) +
                    string.Join("", Enumerable.Range(0, rnd.Next(3, maxLength + 1)).Select(x => (char)rnd.Next(97, 123)));
        }

        public override bool Equals(object? obj)
        {
            return obj is Stone stone &&
                   CountInCountries.SequenceEqual(stone.CountInCountries) &&
                   Name == stone.Name &&
                   SkinColor.Equals(stone.SkinColor);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CountInCountries, Name, SkinColor);
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }
    }
}