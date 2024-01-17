using static UserInput.CustomConsoleInput;

namespace Task
{
    public class Artiodactyl : Mammal
    {

        public new MammalSubclass Subclass
        {
            get { return MammalSubclass.Theria; }
        }

        public enum ArtiodactylSuborder
        {
            Tylopoda,
            Ruminants,
            Suina
        }

        public ArtiodactylSuborder Suborder { get; set; }

        public Artiodactyl() { }

        public Artiodactyl(
            string name, int age, double weight, ArtiodactylSuborder suborder) :
            base(name, age, weight, MammalSubclass.Theria)
        {
            Suborder = suborder;
        }

        public Artiodactyl(Artiodactyl copied) : base(copied)
        {
            Suborder = copied.Suborder;
        }

        public void Init()
        {
            base.Init();
            Suborder = (ArtiodactylSuborder)(ReadInt("Введите номер подкласса:\n" +
                "1. Tylopoda\n2. Ruminants\n3. Suina ", "Неверный ввод! Введите целое число от 1 до 3:", 1, 3) - 1);

        }

        public void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Suborder = (ArtiodactylSuborder)rnd.Next(0, 3);
        }

        public void Show()
        {
            base.Show();
            Console.WriteLine($"{Suborder} suborder");
        }

        public bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Artiodactyl artiodactyl && artiodactyl.Suborder == Suborder;
        }

        public int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Suborder);
        }

        public Artiodactyl Clone()
        {
            return new Artiodactyl(this);
        }
    }
}