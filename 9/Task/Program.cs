<<<<<<< HEAD
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Money a = new Money();//Экземпляр класса Money (Рублей = 0, Копеек = 0)
            Money b = new Money(5, 10);//Экземпляр класса Money (Рублей = 5, Копеек = 10)
            Money c = new Money(b);//Экземпляр класса Money (Рублей = 5, Копеек = 10)
            Console.WriteLine($"Количество созданных элементов: {Money.GetCount}");//Вывод количества созданных объектов
            MoneyArray moneyArrayA = new MoneyArray();//Экземпляр класса MoneyArray (Пустой массив)
            WriteArray(moneyArrayA.GetArray());//Вывод массива
            try
            {
                Console.WriteLine("Среднее: " + moneyArrayA.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}\n");
            }
            MoneyArray moneyArrayB = new MoneyArray(10, true);//Экземпляр класса MoneyArray
                                                              //(массив из 10 случайных элементов)
            WriteArray(moneyArrayB.GetArray());//Вывод массива
            Console.WriteLine("Среднее: " + moneyArrayB.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            try
            {
                MoneyArray moneyArrayC = new MoneyArray(3, false);//Экземпляр класса MoneyArray
                                                                  //(массив из 3 элементов, введённых вручную)
                WriteArray(moneyArrayC.GetArray());//Вывод массива
                Console.WriteLine("Среднее: " + moneyArrayC.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}\n");
            }
            a++;//Добалвение копейки
            b--;//Вычитание копейки
            Money e = b + 2 - c - a;//5р 9к + 2к - 5р 10к - 1к
            Console.WriteLine(e.ToString());
            if (e)
            {
                Console.WriteLine("Деньги есть! Гуляем!");
            }
            else
            {
                Console.WriteLine("Денег нет, но вы держитесь!");
            }
            Console.WriteLine((int)b);
            Console.WriteLine($"Количество созданных элементов: {Money.GetCount}");//Вывод количества созданных объектов
        }
        private static void WriteArray(Money[] array)//Вывод массива
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Кошелёк пуст!");
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
        }
    }
=======
﻿namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Money a = new Money();//Экземпляр класса Money (Рублей = 0, Копеек = 0)
            Money b = new Money(5, 10);//Экземпляр класса Money (Рублей = 5, Копеек = 10)
            Money c = new Money(b);//Экземпляр класса Money (Рублей = 5, Копеек = 10)
            Console.WriteLine($"Количество созданных элементов: {Money.GetCount}");//Вывод количества созданных объектов
            try
            {
                Money d = new Money(8, 100);//Копеек не может быть больше 99
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}\n");
            }
            MoneyArray moneyArrayA = new MoneyArray();//Экземпляр класса MoneyArray (Пустой массив)
            WriteArray(moneyArrayA.GetArray());//Вывод массива
            try
            {
                Console.WriteLine("Среднее: " + moneyArrayA.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}\n");
            }
            MoneyArray moneyArrayB = new MoneyArray(10, true);//Экземпляр класса MoneyArray
                                                              //(массив из 10 случайных элементов)
            WriteArray(moneyArrayB.GetArray());//Вывод массива
            Console.WriteLine("Среднее: " + moneyArrayB.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            try
            {
                MoneyArray moneyArrayC = new MoneyArray(3, false);//Экземпляр класса MoneyArray
                                                                  //(массив из 3 элементов, введённых вручную)
                WriteArray(moneyArrayC.GetArray());//Вывод массива
                Console.WriteLine("Среднее: " + moneyArrayC.GetArithmeticMean().ToString());//Вывод арифмитического среднего
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex}\n");
            }
            a++;//Добалвение копейки
            b--;//Вычитание копейки
            Money e = b + 2 - c - a;//5р 9к + 2к - 5р 10к - 1к
            Console.WriteLine(e.ToString());
            if (e)
            {
                Console.WriteLine("Деньги есть! Гуляем!");
            }
            else
            {
                Console.WriteLine("Денег нет, но вы держитесь!");
            }
            Console.WriteLine((int)b);
            Console.WriteLine($"Количество созданных элементов: {Money.GetCount}");//Вывод количества созданных объектов
        }
        private static void WriteArray(Money[] array)//Вывод массива
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Кошелёк пуст!");
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
        }
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}