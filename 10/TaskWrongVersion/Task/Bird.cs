using static UserInput.CustomConsoleInput;

namespace Task
{
    public class Bird : Animal
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

        public Bird() { }

        public Bird(string name, int age, double weight, double wingspan) : base(name, age, weight)
        {
            Wingspan = wingspan;
        }

        public Bird(Bird copied) : base(copied)
        {
            Wingspan = copied.Wingspan;
        }

        public void Init()
        {
            base.Init();
            Wingspan = ReadDouble("Введите размах крыльев:", "Неверный ввод! Введите неотрицательное число:", 0);
        }

        public void InitRandom()
        {
            Random rnd = new();
            base.InitRandom();
            wingspan = rnd.NextDouble() * 5;
        }

        public void Show()
        {
            base.Show();
            Console.WriteLine($"wingspan {wingspan} m");
        }

        public bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Bird bird && bird.wingspan == wingspan;
        }

        public int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Age, Weight, Wingspan);
        }

        public object Clone()
        {
            return new Bird(this);
        }
    }
}