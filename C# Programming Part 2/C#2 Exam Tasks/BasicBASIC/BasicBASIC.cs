namespace BasicBASIC
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class BasicBASIC
    {
        private static int X = 0;
        private static int Y = 0;
        private static int Z = 0;
        private static int W = 0;
        private static int V = 0;
        private static string[] commands = new string[10010];
        private static List<int> commandIds = new List<int>();
        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            ReadInput();

            ExecuteCommands();

            PrintResult();
        }

        private static void ReadInput()
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line.Contains("RUN"))
                {
                    int lastCommandId = commandIds[commandIds.Count - 1];
                    commands[lastCommandId + 1] = "RUN";
                    commandIds.Add(lastCommandId + 1);
                    break;
                }

                string[] lineTokens = line.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                int commandId = int.Parse(lineTokens[0]);
                string command = lineTokens[1].Trim();

                commands[commandId] = command;
                commandIds.Add(commandId);
            }
        }

        private static void ExecuteCommands()
        {
            int commandIndex = 0;

            while (true)
            {
                int commandId = commandIds[commandIndex];
                string command = commands[commandId];

                if (command[0] == 'X' || command[0] == 'Y' || command[0] == 'Z' || command[0] == 'W' || command[0] == 'V')
                {
                    AssignVariable(command);
                    commandIndex++;
                    continue;
                }

                if (command.StartsWith("IF"))
                {
                    string[] commandTokens = command.Split(new string[] { "THEN" }, StringSplitOptions.RemoveEmptyEntries);
                    string boolExpression = commandTokens[0].Substring(2);

                    boolExpression = ReplaceVariablesNames(boolExpression);

                    bool isTrue = IsExpressionTrue(boolExpression);

                    if (isTrue && commandTokens[1].Contains("GOTO"))
                    {
                        int startIndex = commandTokens[1].IndexOf("GOTO") + 4;
                        int lineToGo = int.Parse(commandTokens[1].Substring(startIndex));

                        commandIndex = commandIds.IndexOf(lineToGo);
                        continue;
                    }
                    else if (isTrue)
                    {
                        AssignVariable(commandTokens[1].Trim());
                        continue;
                    }
                    else
                    {
                        commandIndex++;
                    }
                }

                if (command.StartsWith("GOTO"))
                {
                    int startIndex = command.IndexOf("GOTO") + 4;
                    int lineToGo = int.Parse(command.Substring(startIndex));

                    commandIndex = commandIds.IndexOf(lineToGo);
                    continue;
                }

                if (command.StartsWith("CLS"))
                {
                    result.Clear();
                    commandIndex++;
                }

                if (command.StartsWith("PRINT"))
                {
                    string variableName = command.Substring(5).Trim();
                    int value = GetVariableValue(variableName[0]);

                    result.AppendLine(value.ToString());
                    commandIndex++;
                }

                if (command.StartsWith("STOP"))
                {
                    break;
                }

                if (command.StartsWith("RUN"))
                {
                    break;
                }
            }
        }

        private static void AssignVariable(string command)
        {
            char variableToAssign = command[0];
            int startIndex = command.IndexOf('=') + 1;
            string expression = command.Substring(startIndex);
            int firstValue = 0;
            int secondValue = 0;
            char arithmeticOperator = '\0';

            expression = ReplaceVariablesNames(expression);

            if (expression.Contains("-"))
            {
                string[] expressionTokens = expression.Split('-');

                firstValue = int.Parse(expressionTokens[0].Trim() == string.Empty ? "0" : expressionTokens[0]);
                secondValue = int.Parse(expressionTokens[1].Trim() == string.Empty ? "0" : expressionTokens[1]);
                arithmeticOperator = '-';
            }
            else if (expression.Contains("+"))
            {
                string[] expressionTokens = expression.Split('+');

                firstValue = int.Parse(expressionTokens[0].Trim() == string.Empty ? "0" : expressionTokens[0]);
                secondValue = int.Parse(expressionTokens[1].Trim() == string.Empty ? "0" : expressionTokens[1]);
                arithmeticOperator = '+';
            }
            else
            {
                firstValue = int.Parse(expression);
                arithmeticOperator = '+';
            }

            int valueToAssign = PerformArithmeticOperation(firstValue, secondValue, arithmeticOperator);

            switch (variableToAssign)
            {
                case 'X': X = valueToAssign; break;
                case 'Y': Y = valueToAssign; break;
                case 'Z': Z = valueToAssign; break;
                case 'W': W = valueToAssign; break;
                case 'V': V = valueToAssign; break;
            }
        }

        private static int PerformArithmeticOperation(int firstValue, int secondValue, char arithmeticOperator)
        {
            switch (arithmeticOperator)
            {
                case '+': return firstValue + secondValue;
                case '-': return firstValue - secondValue;
            }

            return 0;
        }

        private static string ReplaceVariablesNames(string expression)
        {
            if (expression.Contains("X"))
            {
                int value = GetVariableValue('X');
                expression = expression.Replace("X", value.ToString());
            }

            if (expression.Contains("Y"))
            {
                int value = GetVariableValue('Y');
                expression = expression.Replace("Y", value.ToString());
            }

            if (expression.Contains("Z"))
            {
                int value = GetVariableValue('Z');
                expression = expression.Replace("Z", value.ToString());
            }

            if (expression.Contains("W"))
            {
                int value = GetVariableValue('W');
                expression = expression.Replace("W", value.ToString());
            }

            if (expression.Contains("V"))
            {
                int value = GetVariableValue('V');
                expression = expression.Replace("V", value.ToString());
            }

            return expression;
        }

        private static int GetVariableValue(char variable)
        {
            switch (variable)
            {
                case 'X': return X;
                case 'Y': return Y;
                case 'Z': return Z;
                case 'W': return W;
                case 'V': return V;
            }

            return 0;
        }

        private static bool IsExpressionTrue(string boolExpression)
        {
            boolExpression = boolExpression.Replace(" ", string.Empty);

            string boolOperator = string.Empty;

            if (boolExpression.Contains("="))
            {
                boolOperator = "=";
            }
            else if (boolExpression.Contains("<"))
            {
                boolOperator = "<";
            }
            else if (boolExpression.Contains(">"))
            {
                boolOperator = ">";
            }

            string[] expressionTokens = boolExpression.Split(new string[] { boolOperator }, StringSplitOptions.RemoveEmptyEntries);
            int firstValue = int.Parse(expressionTokens[0]);
            int secondValue = int.Parse(expressionTokens[1]);

            switch (boolOperator)
            {
                case "=": return firstValue == secondValue;
                case "<": return firstValue < secondValue;
                case ">": return firstValue > secondValue;
            }

            return false;
        }

        private static void PrintResult()
        {
            Console.Write(result);
        }
    }
}