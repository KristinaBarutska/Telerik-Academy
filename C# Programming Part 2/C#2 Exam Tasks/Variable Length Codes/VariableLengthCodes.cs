namespace _04.VariableLengthCodes
{
    using System;
    using System.Linq;
    using System.Text;

    public class VariableLengthCodes
    {
        public static void Main()
        {
            byte[] numbers;
            int L;
            string[] lines;

            ReadInput(out numbers, out L, out lines);

            string bitSequence = GetTheWholeBitsSequence(numbers);
            string[] characters = bitSequence.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);
            char[] table = GetCharTable(lines);
            var result = new StringBuilder();

            for (int i = 0; i < characters.Length; ++i)
            {
                string symbol = characters[i];
                Console.Write(table[symbol.Length]);
            }

            Console.WriteLine();
        }

        private static void ReadInput(out byte[] numbers, out int L, out string[] lines)
        {
            numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => byte.Parse(n)).ToArray();
            L = int.Parse(Console.ReadLine());
            lines = new string[L];

            for (int i = 0; i < L; ++i)
            {
                lines[i] = Console.ReadLine();
            }
        }

        private static string GetTheWholeBitsSequence(byte[] numbers)
        {
            var sequence = new StringBuilder();

            for (int i = 0; i < numbers.Length; ++i)
            {
                int currentNumber = numbers[i];
                string currentBitRepresentation = Convert.ToString(currentNumber, 2).PadLeft(8, '0');
                sequence.Append(currentBitRepresentation);
            }

            return sequence.ToString();
        }

        private static char[] GetCharTable(string[] lines)
        {
            var table = new char[lines.Length + 1];

            for (int i = 0; i < lines.Length; ++i)
            {
                string currentLine = lines[i];
                char character = currentLine[0];
                int number = int.Parse(currentLine.Substring(1, currentLine.Length - 1));
                table[number] = character;
            }

            return table;
        }
    }
}