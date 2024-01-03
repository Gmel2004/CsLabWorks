<<<<<<< HEAD
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
    public class MoneyArray
    {
        private Money[] array = new Money[0];
        public MoneyArray() { }
        public MoneyArray(int count, bool isRandom = true)
        {
            if (count < 0)
            {
                throw new Exception("Ошибка! Количество элементов не может быть отрицательным!");
            }
            array = new Money[count];
            FillArray(count, isRandom);
        }
        public MoneyArray(MoneyArray arrayObj)
        {
            array = arrayObj.array;
        }
        public void FillArray(int count, bool isRandom = true)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
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
                        "Неверный ввод! Количество копеек должно находиться в диапазоне от 0 до 99",
                        beginFirst: 0, beginSecond: 0, endSecond: 99);
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
    }
}
=======
﻿using static UserInput.CustomConsoleInput;

namespace Task
{
    public class MoneyArray
    {
        private Money[] array = new Money[0];
        public MoneyArray() { }
        public MoneyArray(int count, bool isRandom = true)
        {
            if (count < 0)
            {
                throw new Exception("Ошибка! Количество элементов не может быть отрицательным!");
            }
            array = new Money[count];
            FillArray(count, isRandom);
        }
        public MoneyArray(MoneyArray arrayObj)
        {
            array = arrayObj.array;
        }
        public void FillArray(int count, bool isRandom = true)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
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
                        "Неверный ввод! Количество копеек должно находиться в диапазоне от 0 до 99",
                        beginFirst: 0, beginSecond: 0, endSecond: 99);
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
    }
}
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
