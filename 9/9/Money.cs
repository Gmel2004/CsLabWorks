namespace _9
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Money
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        private static int count = 0;

        private int rubles;
        private int kopeks;
        public int Rubles
        {
            get => rubles;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Рублей не может быть меньше нуля!");
                }
                rubles = value;
            }
        }
        public int Kopeks
        {
            get => kopeks;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Ошибка! Копеек не может быть меньше нуля!");
                }
                Rubles += value / 100;
                kopeks = value % 100;
            }
        }
        public Money() : this(0, 0) { }

        public Money(Money money) : this(money.Rubles, money.Kopeks) { }
        public Money(int rubles, int kopeks)
        {
            Rubles = rubles;
            Kopeks = kopeks;
            count++;
        }

        public static int GetCount => count;

        public Money SubtractKopeks(int kopeks)
        {
            if (kopeks < 0)
            {
                throw new Exception("Ошибка! Количество копеек не может быть меньше нуля!");
            }

            if (ConvertToKopeks() < kopeks)
            {
                throw new Exception("Ошибка! Количество копеек и рублей не может быть меньше нуля!");
            }

            return new(0, ConvertToKopeks() - kopeks);
        }

        public bool IsEmpty() => Rubles == 0 && Kopeks == 0;

        public int ConvertToKopeks()
        {
            return Rubles * 100 + Kopeks;
        }

        public static Money operator --(Money money)
        {
            var temp = money.SubtractKopeks(1);
            money.Kopeks = temp.Kopeks;
            money.Rubles = temp.Rubles;
            return money;
        }

        public static Money operator ++(Money money)
        {
            money.Kopeks += 1;
            return money;
        }

        public static explicit operator int(Money money)
        {
            return money.Rubles;
        }

        public static implicit operator bool(Money money)
        {
            return !money.IsEmpty();
        }

        public override string ToString()
        {
            return $"Рубли: {Rubles} копейки: {Kopeks}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Money money &&
                   Rubles == money.Rubles &&
                   Kopeks == money.Kopeks;
        }

        public static Money operator -(Money first, Money second)
        {
            Money result = first.SubtractKopeks(second.ConvertToKopeks());
            return result;
        }

        public static Money operator +(Money money, int kopeks)
        {
            Money result = new(money);
            result.Kopeks += kopeks;
            return result;
        }
        public static Money operator +(int kopeks, Money money) => money + kopeks;
    }
}