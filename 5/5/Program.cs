using static UserInput.CustomConsoleInput;

namespace _5
{
    public class Program
    {
        private static int[] oneArray = new int[0];//Одномерный массив
        private static int[,] twoArray = new int[0, 0];//Двумерный массив
        private static int[][] tornArray = new int[0][];//Рваный массив
        private static Random rnd = new Random();//Экземпляр для ДСЧ
        private static void Main()
        {
            string mainMessage = "Введите номер команды:\n" +
                "1. Работа с одномерным массивом\n" +
                "2. Работа с двумерным массивом\n" +
                "3. Работа с рванным массивом\n" +
                "4. Выход";
            string errorMessage = "Неверный ввод! Введите число от 1 до 4:";
            int answer = 0;
            while (answer != 4)
            {
                Console.Clear();
                answer = ReadInt(mainMessage, errorMessage, 1, 4);
                switch (answer)
                {
                    case 1:
                        DoActionsWithOneArray();
                        break;
                    case 2:
                        DoActionsWithTwoArray();
                        break;
                    case 3:
                        DoActionsWithTornArray();
                        break;
                }
            }
        }

        private static void DoActionsWithOneArray()//Выполнить действия с одномерным массивом
        {
            var mainMessage = "Введите номер команды:\n" +
                "1. Создать/пересоздать массив\n" +
                "2. Заполнить массив используя ДСЧ\n" +
                "3. Заполнить массив используя клавиатуру\n" +
                "4. Вывести массив на экран\n" +
                "5. Добавить K элементов в начало массива\n" +
                "6. Назад";
            var errorMessage = "Неверный ввод! Введите число от 1 до 6";
            int answer = 0;
            while (answer != 6)
            {
                answer = ReadInt(mainMessage, errorMessage, 1, 6);
                switch (answer)
                {
                    case 1:
                        oneArray = CreateOneArray();
                        break;
                    case 2:
                        FillRandom(oneArray);
                        break;
                    case 3:
                        FillInManually(oneArray);
                        break;
                    case 4:
                        WriteArray(oneArray);
                        break;
                    case 5:
                        AddIntoBegin(ref oneArray);
                        break;
                }
            }
        }

        private static void DoActionsWithTwoArray()//Выполнить действия с двумерным массивом
        {
            var mainMessage = "Введите номер команды:\n" +
                "1. Создать/пересоздать массив\n" +
                "2. Заполнить массив используя ДСЧ\n" +
                "3. Заполнить массив используя клавиатуру\n" +
                "4. Вывести массив на экран\n" +
                "5. Удалить строки в заданном диапазоне\n" +
                "6. Назад";
            var errorMessage = "Неверный ввод! Введите число от 1 до 6";
            int answer = 0;
            while (answer != 6)
            {
                answer = ReadInt(mainMessage, errorMessage, 1, 6);
                switch (answer)
                {
                    case 1:
                        twoArray = CreateTwoArray();
                        break;
                    case 2:
                        FillRandom(twoArray);
                        break;
                    case 3:
                        FillInManually(twoArray);
                        break;
                    case 4:
                        WriteArray(twoArray);
                        break;
                    case 5:
                        DeleteRows(ref twoArray);
                        break;
                }
            }
        }

        private static void DoActionsWithTornArray()//Выполнить действия с рваным массивом
        {
            var mainMessage = "Введите номер команды:\n" +
                "1. Создать/пересоздать массив\n" +
                "2. Заполнить массив используя ДСЧ\n" +
                "3. Заполнить массив используя клавиатуру\n" +
                "4. Вывести массив на экран\n" +
                "5. Добавить строку в начало массива\n" +
                "6. Назад";
            var errorMessage = "Неверный ввод! Введите число от 1 до 6";
            int answer = 0;
            while (answer != 6)
            {
                answer = ReadInt(mainMessage, errorMessage, 1, 6);
                switch (answer)
                {
                    case 1:
                        tornArray = CreateTornArray();
                        break;
                    case 2:
                        FillRandom(tornArray);
                        break;
                    case 3:
                        FillInManually(tornArray);
                        break;
                    case 4:
                        WriteArray(tornArray);
                        break;
                    case 5:
                        AddRowIntoBegin(ref tornArray);
                        break;
                }
            }
        }

        private static int[] CreateOneArray()
        {
            int count = ReadInt("Введите количество элементов: ",
                "Неверный ввод! Введите целое неотрицательное число: ", 0);
            return CreateOneArray(count);
        }//Создать одномерный массив

        public static int[] CreateOneArray(int count)
        {
            Console.WriteLine("Операция успешно выполнена!");
            return new int[count];
        }//Создать одномерный массив

        private static int[,] CreateTwoArray()//Создать двумерный массив
        {
            int rowsCount = ReadInt("Введите количество строк: ",
                "Неверный ввод! Введите целое неотрицательное число: ", 0);
            int columnsCount = ReadInt("Введите количество столбцов: ",
                "Неверный ввод! Введите целое неотрицательное число: ", 0);
            return CreateTwoArray(rowsCount, columnsCount);
        }

        public static int[,] CreateTwoArray(int rowsCount, int columnsCount)
        {
            Console.WriteLine("Операция успешно выполнена!");
            return new int[rowsCount, columnsCount];
        }//Создать двумерный массив

        public static int[][] CreateTornArray()
        {
            int rowsCount = ReadInt("Введите количество строк: ",
                "Неверный ввод! Введите целое неотрицательное число: ", 0);
            int[][] array = new int[rowsCount][];
            var lenght = 0;
            for (int i = 0; i < rowsCount; i++)
            {
                lenght = ReadInt("Введите длину строки: ",
                "Неверный ввод! Введите целое неотрицательное число: ", 0);
                array[i] = new int[lenght];
            }
            Console.WriteLine("Операция успешно выполнена!");
            return array;
        }//Создать рваный массив

        private static void FillRandom(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rnd.Next(-500, 500 + 1);
                }
                Console.WriteLine("Массив успешно заполнен!");
            }
        }//Случайно заполнить одномерный массив

        private static void FillRandom(int[,] array)
        {
            if (array.GetLength(0) == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = rnd.Next(-500, 500 + 1);
                    }
                }
                Console.WriteLine("Массив успешно заполнен!");
            }
        }//Случайно заполнить двумерный массив

        private static void FillRandom(int[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = rnd.Next(-500, 500 + 1);
                    }
                }
                Console.WriteLine("Массив успешно заполнен!");
            }
        }//Случайно заполнить рваный массив

        private static void FillInManually(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = ReadInt("Введите элемент:",
                        "Неверный ввод!\n" +
                        "Элемент должен являться числом.\n" +
                        "Повторите попытку:");
                }
                Console.WriteLine("Операция успешно выполнена!");
            }
        }//Заполнить одномерный массив вручную

        private static void FillInManually(int[,] array)
        {
            if (array.GetLength(0) == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = ReadInt("Введите элемент:",
                            "Неверный ввод!\n" +
                            "Элемент должен являться числом.\n" +
                            "Повторите попытку:");
                    }
                }
                Console.WriteLine("Массив успешно заполнен!");
            }
        }//Заполнить двумерный массив вручную

        private static void FillInManually(int[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        array[i][j] = ReadInt("Введите элемент:",
                            "Неверный ввод!\n" +
                            "Элемент должен являться числом.\n" +
                            "Повторите попытку:");
                    }
                }
                Console.WriteLine("Массив успешно заполнен!");
            }
        }//Заполнить рваный массив вручную

        private static void WriteArray(int[] array)
        {
            Console.WriteLine("{" + string.Join(", ", array) + '}');
        }//Вывести одномерный массив

        private static void WriteArray(int[,] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j != 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(array[i, j]);
                }
                if (i < array.GetLength(0) - 1)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine('}');
        }//Вывести двумерный массив

        private static void WriteArray(int[][] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine(string.Join(", ", array[i]));
            }
            if (array.Length != 0)
            {
                Console.Write(string.Join(", ", array[array.Length - 1]));
            }
            Console.WriteLine('}');
        }//Вывести рваный массив

        private static void AddIntoBegin(ref int[] array)
        {
            int count = ReadInt("Введите количество элементов: ",
                "Неверный ввод! Введите неотрицательное целое число: ", 0);
            int[] temp = new int[array.Length + count];
            for (int i = 0; i < count; i++)
            {
                temp[i] = ReadInt("Введите элемент: ",
                    "Неверный ввод! Введите число: ");
            }
            array.CopyTo(temp, count);
            array = temp;
            Console.WriteLine("Операция успешно выполнена!");
        }//Добавить K элементов в начало одномерного массива

        private static void DeleteRows(ref int[,] array)
        {
            if (array.GetLength(0) == 0)
            {
                Console.WriteLine("Выполнение операции невозможно! Массив пуст");
            }
            else
            {
                int begin = 0, end = 0;
                do
                {
                    begin = ReadInt("Введите номер начальной строки:",
                    $"Неверный ввод! Введите целое число от 1 до {array.GetLength(0)}:",
                    1, array.GetLength(0)) - 1;
                    end = ReadInt("Введите номер конечной строки:",
                        $"Неверный ввод! Введите целое число от 1 до {array.GetLength(0)}:",
                        1, array.GetLength(0)) - 1;
                    if (begin > end)
                    {
                        Console.WriteLine("Неверный ввод!" +
                            "Номер начальной строки не может быть больше номера конечной." +
                            "Измените границы!");
                    }
                } while (begin > end);
                DeleteRows(ref array, begin, end);
            }
        }//Удалить строки в двумерном массиве в заданном диапазоне

        public static void DeleteRows(ref int[,] array, int begin, int end)
        {
            int[,] temp = new int[array.GetLength(0) - end + begin - 1, array.GetLength(1)];
            for (int i = 0; i < begin; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    temp[i, j] = array[i, j];
                }
            }
            for (int i = end + 1; i < array.GetLength(0); i++, begin++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    temp[begin, j] = array[i, j];
                }
            }
            array = temp;
            Console.WriteLine("Операция успешно выполнена!");
        }//Удалить строки в двумерном массиве в заданном диапазоне

        private static void AddRowIntoBegin(ref int[][] array)
        {
            int lenght = ReadInt("Введите длину строки: ",
                "Неверный ввод! Введите неотрицательное целое число: ", 0);
            int[][] temp = new int[array.Length + 1][];
            temp[0] = new int[lenght];
            for (int i = 0; i < lenght; i++)
            {
                temp[0][i] = ReadInt("Введите элемент: ",
                    "Неверный ввод! Введите целое число: ");
            }
            array.CopyTo(temp, 1);
            array = temp;
            Console.WriteLine("Операция успешно выполнена!");
        }//Добавить строку в начало массива
    }
}