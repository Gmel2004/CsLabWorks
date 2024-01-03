<<<<<<< HEAD
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Bird : Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        protected double wingspan;
        
        public double Wingspan
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Ошибка! {nameof(Wingspan)} не может быть меньше 0!");
                }
                wingspan = value;
            }
            get { return wingspan; }
        }
        public new void Init()
        {
            base.Init();
            Wingspan = ReadDouble("Введите рахмах крыльев:", "Неверный ввод! Введите неотрицательное число:", 0);
        }
        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            wingspan = rnd.NextDouble() * 5;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"wingspan {wingspan} m");
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Bird bird && bird.wingspan == wingspan;
        }
    }
}
=======
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Bird : Animal
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        protected double wingspan;
        
        public double Wingspan
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Ошибка! {nameof(Wingspan)} не может быть меньше 0!");
                }
                wingspan = value;
            }
            get { return wingspan; }
        }
        public new void Init()
        {
            base.Init();
            Wingspan = ReadDouble("Введите рахмах крыльев:", "Неверный ввод! Введите неотрицательное число:", 0);
        }
        public new void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            wingspan = rnd.NextDouble() * 5;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"wingspan {wingspan} m");
        }

        public new bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Bird bird && bird.wingspan == wingspan;
        }
    }
}
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
