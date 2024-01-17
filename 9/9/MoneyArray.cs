using static UserInput.CustomConsoleInput;

namespace _9
{
    public class MoneyArray
    {
        private Money[] array = new Money[0];

        public MoneyArray() { }

        public MoneyArray(int count, bool isRandom = true)
        {
            if (count < 0)
            {
                throw new ArgumentException("Ошибка! Количество элементов не может быть отрицательным!");
            }
            array = new Money[count];
            FillArray(0, count, isRandom);
        }

        public MoneyArray(MoneyArray arrayObj)
        {
            array = arrayObj.array.ToArray();
        }

        public void FillArray(int ind, int count, bool isRandom = true)
        {
            if (ind < 0
                || ind >= array.Length
                || ind + count - 1 >= array.Length)
            {
                throw new ArgumentException("Ошибка! Выход за границы массива!");
            }
            Random rnd = new Random();
            for (int i = ind; i < ind + count; i++)
            {
                array[i] = new Money();
                if (isRandom)
                {
                    array[i] = new Money(rnd.Next(0, 512), rnd.Next(0, 100));
                }
                else
                {
                    var (rubles, kopeks) = ReadIntPair("Введите количество рублей и копеек через пробел:",
                        "Неверный ввод! Количество рублей не может быть отрицательным",
                        "Неверный ввод! Количество копеек должно быть неотрицательным",
                        beginFirst: 0, beginSecond: 0);
                    array[i] = new Money(rubles, kopeks);
                }
            }
        }

        public void Resize(int count)
        {
            Money[] tmp = new Money[count];
            for (int i = 0; i < tmp.Length && i < array.Length; i++)
            {
                tmp[i] = array[i];
            }
            array = tmp;
        }

        public Money this[int i]
        {
            set
            {
                array[i] = value;
            }
            get
            {
                if (i < 0 || i >= array.Length)
                {
                    throw new Exception("Ошибка! Выход за границы массива!");
                }
                return array[i];
            }
        }

        public Money[] GetArray()
        {
            return array;
        }

        public Money GetArithmeticMean()
        {
            if (array.Length == 0)
            {
                throw new Exception("Выполнение операции невозможно! Массив пуст!");
            }
            double arithmeticMeanDouble = array.Average(x => x.ConvertToKopeks());
            Money result = new Money((int)(arithmeticMeanDouble / 100), (int)(arithmeticMeanDouble % 100));
            return result;
        }

        public override bool Equals(object? obj)
        {
            bool isEquals = false;
            if (obj is MoneyArray array && array.GetArray().Length == GetArray().Length)
            {
                isEquals = true;
                for (int i = 0; i < GetArray().Length && isEquals; i++)
                {
                    isEquals = array.GetArray()[i] == GetArray()[i];
                }
            }
            return isEquals;
        }
    }
}