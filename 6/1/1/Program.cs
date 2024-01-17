using static UserInput.CustomConsoleInput;

namespace _1
{
    public class Program
    {
        private static Random rnd = new Random();

        private static void Main(string[] args)
        {
            string mainMessage = "Введите номер команды:\n" +
                "1. Создать/пересоздать одномерный массив\n" +
                "2. Заполнить массив используя ДСЧ\n" +
                "3. Заполнить массив вручную\n" +
                "4. Удалить все цифры из массива\n" +
                "5. Вывести массив на экран\n" +
                "6. Отчистить консоль\n" +
                "7. Выход";
            char[] array = new char[0];
            string errorMessage = "Неверный ввод! Введите число от 1 до 7:";
            int answer = 0;
            while (answer != 7)
            {
                answer = ReadInt(mainMessage, errorMessage, 1, 7);
                switch (answer)
                {
                    case 1:
                        array = CreateOneArray();
                        break;
                    case 2:
                        FillRandom(array);
                        break;
                    case 3:
                        FillInManually(array);
                        break;
                    case 4:
                        RemoveAllDigits(ref array);
                        break;
                    case 5:
                        WriteArray(array);
                        break;
                    case 6:
                        Console.Clear();
                        break;
                }
            }
        }

        private static char[] CreateOneArray()//Создать одномерный массив
        {
            int count = ReadInt("Введите количество элементов: ",
                "Введите целое неотрицательное число: ", 0);
            Console.WriteLine("Массив создан!");
            return new char[count];
        }

        private static void FillRandom(char[] array)//Случайно заполнить одномерный массив
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (char)rnd.Next(0, 256);
                }
                Console.WriteLine("Операция успешно выполнена!");
            }
        }

        private static void FillInManually(char[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = ReadChar("Введите элемент",
                        "Неверный ввод!\n" +
                        "Элемент должен являться символом.\n" +
                        "Повторите попытку:");
                }
                Console.WriteLine("Операция успешно выполнена!");
            }
        }//Заполнить вручную одномерный массив

        public static void RemoveAllDigits(ref char[] array)//Удалить все цифры из одномерного массива
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст! Выполнение операции невозможно!");
            }
            else
            {
                char[] arrayWithoutDigits = array.Where(x => !char.IsDigit(x)).ToArray();
                if (array.Length == arrayWithoutDigits.Length)
                {
                    Console.WriteLine("Выполнение операции невозможно! Массив не содержит цифр");
                }
                else
                {
                    array = arrayWithoutDigits;
                    Console.WriteLine("Операция успешно выполнена!");
                }
            }
        }

        private static void WriteArray(char[] array)//Вывести одномерный массив
        {
            Console.WriteLine("{" + string.Join(", ", array) + '}');
        }
    }
}