using static UserInput.CustomConsoleInput;

namespace _2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int answer = ReadInt("Введите номер команды:\n" +
                "1. Ввести предложение с клавиатуры\n" +
                "2. Сгенерировать предложение автоматически",
                "Неверный ввод! Введите число от 1 до 2:", 1, 2);
            string message = "";
            if (answer == 1)
            {
                message = ReadString("Введите предложение:", "Неверный ввод! Введите непустую строку:");
            }
            else
            {
                message = GenerateMessage();
            }
            Console.Clear();
            var lexis = SplitIntoTokens(message);
            Console.WriteLine("Предложение до: " + message + '\n' +
                "Предложение после: " + ReverseAndSort(lexis.Item1, lexis.Item2));
        }

        public static string GenerateMessage()
        {
            string[] words = new string[10] { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять" };
            string[] splits = new string[10] { ",", ".", ":", ".", "?", "!", ";", "!?", "...", "?!" };
            Random rnd = new Random();
            int countOfWords = rnd.Next(5, 20);
            string message = "";
            int lastIndexOfWord = rnd.Next(0, 10);
            message += words[lastIndexOfWord];

            for (int i = 1; i < countOfWords; i++)
            {
                message += " ";
                int IndexOfWord = rnd.Next(0, 10);
                if (IndexOfWord == lastIndexOfWord)
                {
                    IndexOfWord = (IndexOfWord + 1) % 10;
                }
                lastIndexOfWord = IndexOfWord;
                message += words[IndexOfWord];
                message += splits[rnd.Next(0, 10)];
            }
            return message;
        }

        public static (List<string>, List<string>) SplitIntoTokens(string input)
        {
            List<string> splits = new List<string>();
            List<string> words = new List<string>();
            int beginSplit = -1;
            string word = "";

            for (int i = 0; i < input.Length; i++)
            {

                if (" .?!,;:".Contains(input[i]))
                {
                    if (beginSplit == -1)
                    {
                        beginSplit = i;
                        if (word != "")
                        {
                            words.Add(word);
                            word = "";
                        }
                    }
                }
                else
                {
                    word += input[i];
                    if (beginSplit != -1)
                    {
                        splits.Add(input.Substring(beginSplit, i - beginSplit));
                        beginSplit = -1;
                    }
                }
            }
            if (word.Length > 0)
            {
                words.Add(word);
            }
            if (beginSplit != -1)
            {
                splits.Add(input.Substring(beginSplit, input.Length - beginSplit));
            }

            return (words, splits);
        }

        public static string ReverseAndSort(List<string> words, List<string> splits)
        {
            words = words.
                Select(x => string.Join("", x.Reverse())).
                ToList();
            words.Sort();

            string output = "";

            int numberOfWord = 0;
            int numberOfSplit = 0;

            while (numberOfWord < words.Count || numberOfSplit < splits.Count)
            {
                if (numberOfWord < words.Count)
                {
                    output += words[numberOfWord++];
                }
                if (numberOfSplit < splits.Count)
                {
                    output += splits[numberOfSplit++];
                }
            }
            return output;
        }
    }
}