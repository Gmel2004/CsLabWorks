using System.Diagnostics;

namespace Banchmark
{
    public static class Banchmark
    {
        public static double MeasureTime(Action action)
        {
            var sw = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                action();
            }
            int n = 100;
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                action();
            }
            sw.Stop();
            return sw.Elapsed.Ticks / n;
        }
    }
}
