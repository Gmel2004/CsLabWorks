namespace _3
{
    public class Program
    {
        public static void Main()
        {
            double a = 1000, b = 0.0001, dValue1, dValue2, dValue3, dValue4, dValue5, dValue6, dValue7, dAnswer;
            dValue1 = a * a * a;
            dValue2 = b * b * b;

            dValue3 = Math.Pow(a + b, 4);
            dValue4 = dValue3 - dValue1 * a;

            dValue5 = 6 * a * a * b * b;
            dValue6 = dValue5 + 4 * a * dValue2 + dValue2 * b;
            dValue7 = dValue6 + 4 * dValue1 * b;

            dAnswer = dValue4 / dValue7;

            Console.WriteLine($"ответ для double: {dAnswer}");

            float fValue1, fValue2, fValue3, fValue4, fValue5, fValue6, fValue7, fAnswer;
            fValue1 = (float)(a * a * a);
            fValue2 = (float)(b * b * b);

            fValue3 = (float)Math.Pow(a + b, 4);
            fValue4 = fValue3 - fValue1 * (float)a;

            fValue5 = (float)(6 * a * a * b * b);
            fValue6 = fValue5 + (float)(4 * a * fValue2 + fValue2 * b);
            fValue7 = fValue6 + (float)(4 * fValue1 * b);

            fAnswer = fValue4 / fValue7;

            Console.WriteLine($"ответ для float: {fAnswer}");
        }
    }
}