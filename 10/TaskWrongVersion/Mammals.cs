<<<<<<< HEAD
﻿using System;
using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    internal class Mammal : Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public enum MammalSubclass
        {
            Monotremes,
            Theria
        }

        public MammalSubclass Subclass { get; set; }

        public new void Init()
        {
            base.Init();
            Subclass = (MammalSubclass)(ReadInt("Введите номер подкласса:\n" +
                "1. Monotremes\n2. Theria", "Неверный ввод! Введите целое число от 1 до 2:", 1, 2) - 1);
        }

        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Subclass = (MammalSubclass)rnd.Next(0, 2);
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"{Subclass} subclass");
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Mammal mammal && mammal.Subclass == Subclass;
        }
    }
}
=======
﻿using System;
using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    internal class Mammal : Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public enum MammalSubclass
        {
            Monotremes,
            Theria
        }

        public MammalSubclass Subclass { get; set; }

        public new void Init()
        {
            base.Init();
            Subclass = (MammalSubclass)(ReadInt("Введите номер подкласса:\n" +
                "1. Monotremes\n2. Theria", "Неверный ввод! Введите целое число от 1 до 2:", 1, 2) - 1);
        }

        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Subclass = (MammalSubclass)rnd.Next(0, 2);
        }

        public new void Show()
        {
            base.Show();
            Console.WriteLine($"{Subclass} subclass");
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Mammal mammal && mammal.Subclass == Subclass;
        }
    }
}
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
