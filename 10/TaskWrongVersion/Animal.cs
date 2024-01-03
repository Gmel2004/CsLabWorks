<<<<<<< HEAD
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    abstract public class Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        protected string? name;
        protected int age;
        protected double weight;

        public string Name
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"Ошибка! {nameof(Name)} не может являться пустой строкой!");
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

        public void Init()
        {
            Name = ReadString("Введите имя животного:", "Неверный ввод! Введите непустую строку:");
            Age = ReadInt("Введите возраст животного:", "Неверный ввод! Введите неотрицательное целое число:", 0);
            Weight = ReadDouble("Введите вес животного:", "Неверный ввод! Введите неотрицательное число:", 0);
        }

        public void InitRandom()
        {
            Random rnd = new Random();
            Name = (char)rnd.
                Next(65, 91) +
                string.Join("", Enumerable.Range(0, rnd.Next(3, 7)).Select(x => (char)rnd.Next(97, 123)));
            Age = rnd.Next(0, 100);
            Weight = rnd.Next(0, 100);
        }

        public void Show()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine($"{Age} y. o.");
            Console.WriteLine($"{Weight} kg");
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
    }
}
=======
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    abstract public class Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        protected string? name;
        protected int age;
        protected double weight;

        public string Name
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"Ошибка! {nameof(Name)} не может являться пустой строкой!");
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

        public void Init()
        {
            Name = ReadString("Введите имя животного:", "Неверный ввод! Введите непустую строку:");
            Age = ReadInt("Введите возраст животного:", "Неверный ввод! Введите неотрицательное целое число:", 0);
            Weight = ReadDouble("Введите вес животного:", "Неверный ввод! Введите неотрицательное число:", 0);
        }

        public void InitRandom()
        {
            Random rnd = new Random();
            Name = (char)rnd.
                Next(65, 91) +
                string.Join("", Enumerable.Range(0, rnd.Next(3, 7)).Select(x => (char)rnd.Next(97, 123)));
            Age = rnd.Next(0, 100);
            Weight = rnd.Next(0, 100);
        }

        public void Show()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine($"{Age} y. o.");
            Console.WriteLine($"{Weight} kg");
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
    }
}
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
