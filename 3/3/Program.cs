namespace _3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int k = 0; k < 11; k++)
            {
                double x = 0.2 + 0.08 * k;
                Console.WriteLine($"X = {x:f6}\tY = {CalculateValueFunction(x):f6}\tSN = {CalculateSumWithCount(x):f6}\t" +
                    $"SE = {CalculateSumWithEpsilon(x):f6}");
            }
        }
        private static double CalculateSumWithCount(double x)
        {
            double member = (x - 1) / (x + 1);
            double sum = member;
            for (int n = 0; n < 9; n++)
            {
                member = CalculateNextMemberValue(x, n, member);
                sum += member;
            }
            return sum;
        }

        private static double CalculateNextMemberValue(double x, int currentIndex, double prev)//Вычислить сумму n-го члена ряда
        {
            double c = (x - 1) / (x + 1);
            return prev * c * c * (1 - 2.0 / (2 * currentIndex + 3));
        }

        private static double CalculateValueFunction(double x)//Посчитатать значение функции
        {
            return 0.5 * Math.Log(x);
        }
        private static double CalculateSumWithEpsilon(double x)//сумма ряда с заданной точностью
        {
            double member = (x - 1) / (x + 1);
            double sum = member;
            for (int n = 0; Math.Abs(member = CalculateNextMemberValue(x, n, member)) > 0.0001; n++, sum += member) ;
            return sum;
        }
    }
}