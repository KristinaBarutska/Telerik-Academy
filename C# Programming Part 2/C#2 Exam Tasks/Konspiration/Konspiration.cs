namespace Konspiration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Konspiration
    {
        private static string[] methodsCodes;
        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            GetMethodsCodes();

            ExtractMethodsInvocation();

            PrintResult();
        }

        private static void GetMethodsCodes()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var text = new StringBuilder();

            for (int i = 0; i < numberOfLines; i++)
            {
                string line = Console.ReadLine();
                text.AppendLine(line);
            }

            methodsCodes = text
                .ToString()
                .Split(new string[] { "static " }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void ExtractMethodsInvocation()
        {
            for (int k = 1; k < methodsCodes.Length; k++)
            {
                string method = methodsCodes[k];
                string methodName = GetParentMethodName(method.Trim());
                var potentialMethodCall = new StringBuilder();
                bool inMethodName = false;
                bool isLegitMethodCall = false;
                var currentMethodNames = new List<string>();

                int startIndex = method.IndexOf(methodName) + methodName.Length;

                for (int i = startIndex; i < method.Length - 1; i++)
                {
                    if (i < method.Length - 3 && method.Substring(i, 3) == "new")
                    {
                        i += 4;

                        while (char.IsWhiteSpace(method[i]) || char.IsLetter(method[i]))
                        {
                            i++;
                        }

                        i++;
                    }

                    if (char.IsUpper(method[i]))
                    {
                        inMethodName = true;
                    }

                    if (inMethodName)
                    {
                        for (int j = i; j < method.Length; j++)
                        {
                            if (char.IsLetter(method[j]))
                            {
                                potentialMethodCall.Append(method[j]);
                            }

                            if (method[j] == ' ')
                            {
                                while (method[j] == ' ')
                                {
                                    j++;
                                }

                                if (method[j] == '(')
                                {
                                    isLegitMethodCall = true;
                                    inMethodName = false;
                                    i = j;
                                    break;
                                }
                            }

                            if (method[j] == '(')
                            {
                                isLegitMethodCall = true;
                                inMethodName = false;
                                i = j;
                                break;
                            }

                            if (!char.IsLetter(method[j]) && method[j] != '(')
                            {
                                isLegitMethodCall = false;
                                inMethodName = false;
                                i = j;
                                break;
                            }
                        }
                    }

                    if (isLegitMethodCall)
                    {
                        currentMethodNames.Add(potentialMethodCall.ToString());
                        isLegitMethodCall = false;
                    }

                    potentialMethodCall.Clear();
                }

                string count = string.Empty;

                if (currentMethodNames.Count == 0)
                {
                    count = "None";

                    result.AppendLine(string.Format("{0} -> {1}", methodName, count));
                }
                else
                {
                    count = currentMethodNames.Count.ToString();

                    result.AppendLine(string.Format("{0} -> {1} -> {2}", methodName, count, string.Join(", ", currentMethodNames)));
                }
            }
        }

        private static string GetParentMethodName(string method)
        {
            var methodName = new StringBuilder();
            bool inMethodName = false;

            for (int i = 0; i < method.Length; i++)
            {
                if (method[i] == ' ')
                {
                    inMethodName = true;
                    continue;
                }

                if (inMethodName)
                {
                    if (char.IsLetter(method[i]))
                    {
                        methodName.Append(method[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return methodName.ToString();
        }

        private static void PrintResult()
        {
            Console.Write(result);
        }
    }
}