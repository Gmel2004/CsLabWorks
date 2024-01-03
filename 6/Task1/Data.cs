namespace Task1
{
    public class Data
    {
        public int ReadInt(string mainMessage, string errorMessage, int begin = int.MinValue, int end = int.MaxValue)
        {
            int answer = 0;
            Console.WriteLine(mainMessage);
            var isCorrect = int.TryParse(Console.ReadLine(), out answer);
            while (!isCorrect || answer < begin || answer > end)
            {
                Console.WriteLine(errorMessage);
                isCorrect = int.TryParse(Console.ReadLine(), out answer);
            }
            return answer;
        }
        public char ReadChar(string mainMessage, string errorMessage, int begin = 0, int end = 128)
        {
            char answer;
            Console.WriteLine(mainMessage);
            var isCorrect = char.TryParse(Console.ReadLine(), out answer);
            while (!isCorrect || answer < begin || answer > end)
            {
                Console.WriteLine(errorMessage);
                isCorrect = char.TryParse(Console.ReadLine(), out answer);
            }
            return answer;
        }
    }
}
