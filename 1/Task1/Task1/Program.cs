<<<<<<< HEAD
﻿using static UserInput.CustomConsoleInput;

namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            double n = ReadDouble("n?", "n должно являться числом! Попробуйте ввести снова");
            double m = ReadDouble("m?", "m должно являться числом! Попробуйте ввести снова");
            DoActionsWithNM(n, m);

            double x = ReadDouble("x?", "x должно являться числом! Попробуйте снова");
            try
            {
                CalculateTheValue(x);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DoActionsWithNM(double n, double m)
        {
            (_, n, m) = DoFirstActionWithNM(n, m);
            (_, n, m) = DoSecondActionWithNM(n, m);
            DoThirdActionWithNM(n, m);
        }

        public static (double, double, double) DoFirstActionWithNM(double n, double m)
        {
            var action = n++ * m;
            Console.WriteLine($"n++*m = {action}, n = {n}, m = {m}\n");
            return (action, n, m);
        }

        public static (bool, double, double) DoSecondActionWithNM(double n, double m)
        {
            var action = m-- < n;
            Console.WriteLine($"m--<n = {action}, n = {n}, m = {m}\n");
            return (action, n, m);
        }

        public static (bool, double, double) DoThirdActionWithNM(double n, double m)
        {
            var action = ++m > n;
            Console.WriteLine($"++m>n = {action}, n = {n}, m = {m}\n");
            return (action, n, m);
        }

        public static double CalculateTheValue(double x)
        {
            if (x < 0 && x != -1)
            {
                throw new Exception("Нельзя вычислить! Корень из отрицательного числа!\n");
            }
            var answer = Math.Sqrt(x + Math.Pow(Math.Abs(x), 1.0 / 4)) + Math.Abs(x);
            Console.WriteLine($"при x = {x}, √(x + |x|^(1/4)) + |x| = {answer}\n");
            return answer;
        }
    }
=======
﻿namespace Task1 {
    public class Program {
        public static void Main() {
            bool isConvert = false;
            int n = 0, m = 0;

            while (!isConvert) {
                Console.Write("n?");
                isConvert = int.TryParse(Console.ReadLine(), out n);
                if (!isConvert) {
                    Console.WriteLine("n должно являться целым числом! Попробуйте ввести снова");
                }
            }
            isConvert = false;
            while (!isConvert) {
                Console.Write("m?");
                isConvert = int.TryParse(Console.ReadLine(), out m);
                if (!isConvert) {
                    Console.WriteLine("m должно являться целым числом! Попробуйте ввести снова");
                }
            }

            Console.WriteLine($"n++*m = {n++ * m}, n = {n}, m = {m}\n");
            Console.WriteLine($"m--<n = {m-- < n}, n = {n}, m = {m}\n");
            Console.WriteLine($"++m>n = {++m > n}, n = {n}, m = {m}\n");
            
            CalculateTheValue(1);
        }
        public static void CalculateTheValue(double x) {
            if (x < 0 && x != -1) {
                Console.WriteLine("Нельзя вычислить! Корень из отрицательного числа!\n");
            }
            else {
                var answer = Math.Sqrt(x + Math.Pow(Math.Abs(x), 1.0 / 4)) + Math.Abs(x);
                Console.WriteLine($"при x = {x}, √(x + |x|^(1/4)) + |x| = {answer}\n");
            }
        }
    }
>>>>>>> 5ddec8720a38e80661f046408dad51697be8c248
}