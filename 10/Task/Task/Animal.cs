using static UserInput.CustomConsoleInput;

namespace Task
{
    public class Animal : IInit, IComparable<Animal>, ICloneable
    {
        protected string name = "standartName";
        protected int age;
        protected double weight;

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

        public int Age
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Ошибка! {nameof(Age)} не может быть меньше нуля!");
                }
                age = value;
            }
            get { return age; }
        }

        public double Weight
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Ошибка! {nameof(Weight)} не может быть меньше нуля!");
                }
                weight = value;
            }
            get { return weight; }
        }

        public Animal() { }

        public Animal(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        public Animal(Animal copied) : this(copied.Name, copied.Age, copied.Weight) { }

        public virtual void Init()
        {
            Name = ReadString("Введите имя животного:", "Неверный ввод! Введите непустую строку:");
            Age = ReadInt("Введите возраст животного:", "Неверный ввод! Введите неотрицательное целое число:", 0);
            Weight = ReadDouble("Введите вес животного:", "Неверный ввод! Введите неотрицательное число:", 0);
        }

        public virtual void InitRandom()
        {
            Random rnd = new();
            Name = (char)rnd.
                Next(65, 91) +
                string.Join("", Enumerable.Range(0, rnd.Next(3, 7)).Select(x => (char)rnd.Next(97, 123)));
            Age = rnd.Next(0, 100);
            Weight = rnd.Next(0, 100);
        }

        public virtual void Show()
        {
            Console.WriteLine(ToString());
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Animal animal)
            {
                return animal.name == name &&
                    animal.age == age &&
                    animal.weight == weight;
            }
            return false;
        }

        public virtual int CompareTo(Animal? other)
        {
            return string.Compare(Name, other!.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Weight);
        }

        public override string ToString()
        {
            return $"{Name}:\n{Age} y. o.\n{Weight} kg";
        }

        public virtual object Clone()
        {
            return new Animal(this);
        }
    }
}