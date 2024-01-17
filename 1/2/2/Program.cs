namespace _2
{
    public class Program
    {
        public static void Main()
        {
            var x = 0;
            var y = 0;
            if (BelongsToArea(x, y))
            {
                Console.WriteLine($"Точка ({x}, {y}) принадлежит заштрихованной области");
            }
            else
            {
                Console.WriteLine($"Точка ({x}, {y}) не принадлежит заштрихованной области");
            }
        }
        public static bool BelongsToArea(float x, float y)
        {
            var isBelongs = x * x + y * y <= 1 && x * y <= 0;
            return isBelongs;
        }
    }
}