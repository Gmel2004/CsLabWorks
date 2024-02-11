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

        public override void Init()
        {
            base.Init();
            Suborder = (ArtiodactylSuborder)(ReadInt("Введите номер подкласса:\n" +
                "1. Tylopoda\n2. Ruminants\n3. Suina ", "Неверный ввод! Введите целое число от 1 до 3:", 1, 3) - 1);

        }

        public override void InitRandom()
        {
            Random rnd = new Random();
            base.InitRandom();
            Suborder = (ArtiodactylSuborder)rnd.Next(0, 3);
        }

        public override void Show() => Console.WriteLine(ToString());

        public override bool Equals(object? obj)
        {
            return base.Equals(obj) && obj is Artiodactyl artiodactyl && artiodactyl.Suborder == Suborder;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Suborder);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{Suborder} suborder";
        }

        public override Artiodactyl Clone()
        {
            return new Artiodactyl(this);
        }

        public override int CompareTo(Animal? other)
        {
            var order = base.CompareTo(other);

            if (order != 0) return order;

            order = Suborder.CompareTo(((Artiodactyl)other!).Suborder);
            return order;
        }
    }
}