<<<<<<< HEAD
﻿namespace Task
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
        public Money() : this(0, 0) {}

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
=======
﻿namespace Task
{
    public class Money
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
                if (value < 0 || value > 99)
                {
                    throw new Exception("Ошибка! Количество копеек должно быть от 0 до 99!");
                }
                kopeks = value;
            }
        }
        public Money() : this(0, 0) {}

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
            if (this.ConvertToKopeks() < kopeks)
            {
                throw new Exception("Ошибка! Количество копеек и рублей не может быть меньше нуля!");
            }
            Money result = new Money(this);
            if (Kopeks < kopeks)
            {
                var difference = this.ConvertToKopeks() - kopeks;
                result.Rubles = difference / 100;
                result.Kopeks = difference % 100;
            }
            else
            {
                result.Kopeks -= kopeks;
            }
            return result;
        }

        public void AddKopeks(int kopeks)
        {
            if (Kopeks < 0)
            {
                throw new Exception("Ошибка! Количество копеек не может быть меньше нуля!");
            }
            Rubles += (Kopeks + kopeks) / 100;
            Kopeks = (Kopeks + kopeks) % 100;
        }
        public bool isEmpty() => Rubles == 0 && Kopeks == 0;
        public int ConvertToKopeks()
        {
            return Rubles * 100 + Kopeks;
        }
        public static Money operator --(Money money)
        {
            money = money.SubtractKopeks(1);
            return money;
        }
        public static Money operator ++(Money money)
        {
            money.AddKopeks(1);
            return money;
        }

        public static explicit operator int(Money money)
        {
            return money.Rubles;
        }

        public static implicit operator bool(Money money)
        {
            return !money.isEmpty();
        }
        public override string ToString()
        {
            return $"Рубли: {Rubles} копейки: {Kopeks}";
        }
        public static Money operator -(Money first, Money second)
        {
            Money result = first.SubtractKopeks(second.ConvertToKopeks());
            return result;
        }
        public static Money operator +(Money money, int kopeks)
        {
            Money result = new Money(money);
            result.AddKopeks(kopeks);
            return result;
        }
        public static Money operator +(int kopeks, Money money) => money + kopeks;
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}