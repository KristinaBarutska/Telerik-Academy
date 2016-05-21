namespace ConsoleJustification
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleJustification
    {
        private static int n;
        private static int maxLineWidth;
        private static Queue<string> words;
        private static List<int> lastCharIndexesPerLine;
        private static List<StringBuilder> lines;

        public static void Main()
        {
            GetWords();

            GetNewLines();

            InsertWhiteSpaces();

            PrintResult();
        }

        private static void GetWords()
        {
            n = int.Parse(Console.ReadLine());
            maxLineWidth = int.Parse(Console.ReadLine());
            words = new Queue<string>();

            for (int i = 0; i < n; ++i)
            {
                string[] lineWords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < lineWords.Length; ++j)
                {
                    words.Enqueue(lineWords[j]);
                }
            }
        }

        private static void GetNewLines()
        {
            var currentLine = new StringBuilder();
            var lineToAdd = new StringBuilder();
            lastCharIndexesPerLine = new List<int>();
            lines = new List<StringBuilder>();

            while (words.Count > 0)
            {
                string nextWord = words.Peek();

                if (currentLine.Length + nextWord.Length == maxLineWidth)
                {
                    currentLine.Append(words.Dequeue());
                }
                else if (currentLine.Length + nextWord.Length < maxLineWidth)
                {
                    currentLine.Append(words.Dequeue() + " ");
                }
                else
                {
                    lineToAdd = new StringBuilder(currentLine.ToString().Trim());
                    lines.Add(lineToAdd);
                    lastCharIndexesPerLine.Add(lineToAdd.Length);
                    currentLine.Clear();
                }
            }

            if (currentLine.Length != 0)
            {
                lineToAdd = new StringBuilder(currentLine.ToString().Trim());
                lastCharIndexesPerLine.Add(lineToAdd.Length);
                lines.Add(lineToAdd);
            }
        }

        private static void InsertWhiteSpaces()
        {
            foreach (var line in lines)
            {
                if (line.ToString().Contains(" "))
                {
                    if (line.Length < maxLineWidth)
                    {
                        int index = 0;

                        while (line.Length < maxLineWidth)
                        {
                            if (line.Length < maxLineWidth && index == line.Length - 1)
                            {
                                index = 0;
                            }

                            if (index < line.Length)
                            {
                                if (line[index] == ' ')
                                {
                                    line.Insert(index, ' ');
                                    while (line[index] == ' ')
                                    {
                                        index++;
                                    }

                                    if (line.Length == maxLineWidth)
                                    {
                                        break;
                                    }
                                }
                            }

                            index++;
                        }
                    }
                }
            }
        }

        private static void PrintResult()
        {
            var totalResult = new StringBuilder();

            foreach (var line in lines)
            {
                totalResult.AppendLine(line.ToString());
            }

            Console.WriteLine(totalResult.ToString().Trim());
        }
    }
}