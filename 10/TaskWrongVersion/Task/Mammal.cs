using static UserInput.CustomConsoleInput;

namespace Task
{
    public class Mammal : Animal
    {
        public enum MammalSubclass
        {
            Monotremes,
            Theria
        }

        public MammalSubclass Subclass { get; set; }

        public Animal BaseAnimal
        {
            get
            {
                return new Animal(name, age, weight);//возвращает объект базового класса
            }
        }

        public Mammal() { }

        public Mammal(string name, int age, double weight, MammalSubclass subclass) : base(name, age, weight)
        {
            Subclass = subclass;
        }

        public Mammal(Mammal copied) : base(copied)
        {
            Subclass = copied.Subclass;
        }

        public void Init()
        {
            base.Init();
            Subclass = (MammalSubclass)(ReadInt("Введите номер подкласса:\n" +
                "1. Monotremes\n2. Theria", "Неверный ввод! Введите целое число от 1 до 2:", 1, 2) - 1);
        }

        public void InitRandom()
        {
            Random rnd = new();
            base.InitRandom();
            Subclass = (MammalSubclass)rnd.Next(0, 2);
        }

        public string ToString()
        {
            return $"{base.ToString()}\n{Subclass} subclass";//(char)(new Random().Next(0, 256)) + "rrrrr" + (char)(new Random().Next(0, 256));//
        }

        public bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Mammal mammal && mammal.Subclass == Subclass;
        }

        public int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Subclass);
        }

        public object Clone()
        {
            return new Mammal(this);
        }
    }
}