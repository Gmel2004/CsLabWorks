<<<<<<< HEAD
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    internal class Artiodactyl : Mammal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public enum ArtiodactylSuborder
        {
            Tylopoda,
            Ruminants,
            Suina
        }

        public ArtiodactylSuborder Suborder { get; set; }

        public new void Init()
        {
            base.Init();
            Subclass = MammalSubclass.Theria;
            Suborder = (ArtiodactylSuborder)(ReadInt("Введите номер подкласса:\n" +
                "1. Tylopoda\n2. Ruminants\n3. Suina ", "Неверный ввод! Введите целое число от 1 до 3:", 1, 3) - 1);

        }

        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Subclass = MammalSubclass.Theria;
            Suborder = (ArtiodactylSuborder)rnd.Next(0, 3);
        }

        public new void Show()
        {
            
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Artiodactyl artiodactyl && artiodactyl.Suborder == Suborder;
        }
    }
}
=======
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    internal class Artiodactyl : Mammal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        public enum ArtiodactylSuborder
        {
            Tylopoda,
            Ruminants,
            Suina
        }

        public ArtiodactylSuborder Suborder { get; set; }

        public new void Init()
        {
            base.Init();
            Subclass = MammalSubclass.Theria;
            Suborder = (ArtiodactylSuborder)(ReadInt("Введите номер подкласса:\n" +
                "1. Tylopoda\n2. Ruminants\n3. Suina ", "Неверный ввод! Введите целое число от 1 до 3:", 1, 3) - 1);

        }

        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Subclass = MammalSubclass.Theria;
            Suborder = (ArtiodactylSuborder)rnd.Next(0, 3);
        }

        public new void Show()
        {
            
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Artiodactyl artiodactyl && artiodactyl.Suborder == Suborder;
        }
    }
}
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
