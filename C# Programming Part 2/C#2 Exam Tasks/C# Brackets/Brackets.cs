namespace Brackets
{
    using System;
    using System.Text;

    public class Brackets
    {
        private static string indentString;
        private static StringBuilder result;
        private static int indentationsCount = 0;

        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            indentString = Console.ReadLine();
            result = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentLine = Console.ReadLine();
                string currentFormatedLine = FormatLine(currentLine);

                result.AppendLine(currentFormatedLine);
            }

            RemoveFuckingWhiteSpaces();

            RemoveWhitespacesAtTheEndOfLine();

            Console.WriteLine(result.ToString().Trim());
        }

        private static string FormatLine(string line)
        {
            StringBuilder currentFormattedLine = new StringBuilder();
            bool isNewLine = false;
            bool isIndentAppended = false;
            bool isTrimming = true;

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar != ' ')
                {
                    isTrimming = false;
                }

                if (currentChar == '{')
                {
                    string indentation = GetIndentationString(indentationsCount);

                    isNewLine = true;
                    isTrimming = true;
                    indentationsCount++;
                    currentFormattedLine.Append(Environment.NewLine);
                    currentFormattedLine.Append(indentation);
                    currentFormattedLine.Append(currentChar);
                    currentFormattedLine.Append(Environment.NewLine);
                    continue;
                }
                else if (currentChar == '}')
                {
                    if (i != 0)
                    {
                        currentFormattedLine.Append(Environment.NewLine);
                    }

                    indentationsCount--;

                    string indentation = GetIndentationString(indentationsCount);

                    currentFormattedLine.Append(indentation);
                    currentFormattedLine.Append(currentChar);
                    currentFormattedLine.Append(Environment.NewLine);

                    isNewLine = true;
                    isTrimming = true;
                }
                else if (isNewLine)
                {
                    string indentation = GetIndentationString(indentationsCount);

                    currentFormattedLine.Append(indentation);
                    currentFormattedLine.Append(currentChar);
                    isIndentAppended = true;
                    isNewLine = false;
                }
                else
                {
                    if (!isIndentAppended)
                    {
                        isIndentAppended = true;

                        string indentation = GetIndentationString(indentationsCount);
                        currentFormattedLine.Append(indentation);
                    }

                    if (i == line.Length - 1)
                    {
                        currentFormattedLine.Append(currentChar);
                        currentFormattedLine.Append(Environment.NewLine);
                        isIndentAppended = false;
                        continue;
                    }

                    if (!char.IsWhiteSpace(currentChar) || (!isTrimming && currentChar != line[i + 1]))
                    {
                        currentFormattedLine.Append(currentChar);
                    }
                }
            }

            return currentFormattedLine.ToString().Trim();
        }

        private static string GetIndentationString(int indentationCount)
        {
            StringBuilder indentation = new StringBuilder();

            for (int i = 0; i < indentationCount; i++)
            {
                indentation.Append(indentString);
            }

            return indentation.ToString();
        }

        private static void RemoveFuckingWhiteSpaces()
        {
            for (int i = 0; i < result.Length; i++)
            {
                char currentChar = result[i];

                if (currentChar == indentString[indentString.Length - 1])
                {
                    if (result[i + 1] == ' ')
                    {
                        result.Remove(i + 1, 1);
                    }
                }
            }
        }

        private static void RemoveWhitespacesAtTheEndOfLine()
        {
            string[] lines = result.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            result.Clear();

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i].Trim();
                result.AppendLine(currentLine);
            }
        }
    }
}