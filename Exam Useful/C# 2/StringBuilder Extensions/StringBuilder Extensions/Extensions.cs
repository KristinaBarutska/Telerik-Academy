namespace Extensions
{
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder builder, int startIndex, int count)
        {
            var result = new StringBuilder();

            for (int i = startIndex; i <= startIndex + count; i++)
            {
                result.Append(builder[i]);
            }

            return result;
        }

        #region Trim Extension Methods
        public static StringBuilder TrimStart(this StringBuilder builder)
        {
            var result = new StringBuilder();
            int whiteSpacesCount = 0;

            for (int i = 0; i < builder.Length; i++)
            {
                if (char.IsWhiteSpace(builder[i]))
                {
                    whiteSpacesCount++;
                }
                else
                {
                    break;
                }
            }

            for (int i = whiteSpacesCount; i < builder.Length; i++)
            {
                result.Append(builder[i]);
            }

            return result;
        }

        public static StringBuilder TrimEnd(this StringBuilder builder)
        {
            int whiteSpacesCount = 0;

            for (int i = builder.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(builder[i]))
                {
                    whiteSpacesCount++;
                }
                else
                {
                    break;
                }
            }

            return builder.Remove(builder.Length - whiteSpacesCount, whiteSpacesCount);
        }

        public static StringBuilder Trim(this StringBuilder builder)
        {
            var startTrimmed = builder.TrimStart();
            var endTrimmed = startTrimmed.TrimEnd();

            return endTrimmed;
        }
        #endregion

        #region IndexOf Extension Methods
        public static int IndexOf(this StringBuilder builder, char character)
        {
            int start = 0;
            int end = builder.Length - 1;

            return HelperIndexOfCharacter(builder, character, start, end);
        }

        public static int IndexOf(this StringBuilder builder, char character, int start)
        {
            int end = builder.Length - 1;

            return HelperIndexOfCharacter(builder, character, start, end);
        }

        public static int IndexOf(this StringBuilder builder, char character, int start, int end)
        {
            return HelperIndexOfCharacter(builder, character, start, end);
        }

        public static int IndexOf(this StringBuilder builder, string target, bool ignoreCase = false)
        {
            int start = 0;
            int end = builder.Length - target.Length;

            return HelperIndexOfString(builder, target, start, end, ignoreCase);
        }

        public static int IndexOf(this StringBuilder builder, string target, int start, bool ignoreCase = false)
        {
            int end = builder.Length - target.Length;

            return HelperIndexOfString(builder, target, start, end, ignoreCase);
        }

        public static int IndexOf(this StringBuilder builder, string target, int start, int end, bool ignoreCase = false)
        {
            return HelperIndexOfString(builder, target, start, end, ignoreCase);
        }
        #endregion

        #region Contains Extension Methods
        public static bool Contains(this StringBuilder builder, string target)
        {
            int start = 0;
            int end = builder.Length - target.Length;
            int indexOfMatch = HelperIndexOfString(builder, target, start, end, false);

            return indexOfMatch == -1 ? false : true;
        }

        public static bool Contains(this StringBuilder builder, string target, int start)
        {
            int end = builder.Length - target.Length;
            int indexOfMatch = HelperIndexOfString(builder, target, start, end, false);

            return indexOfMatch == -1 ? false : true;
        }

        public static bool Contains(this StringBuilder builder, string target, int start, int end)
        {
            int indexOfMatch = HelperIndexOfString(builder, target, start, end, false);

            return indexOfMatch == -1 ? false : true;
        }

        #endregion

        private static int HelperIndexOfString(StringBuilder builder, string target, int start, int end, bool ignoreCase)
        {
            int index = -1;
            bool isFound = false;

            if (ignoreCase)
            {
                for (int i = start; i <= end; i++)
                {
                    char startChar = builder[i];
                    isFound = true;

                    if (startChar != target[0])
                    {
                        continue;
                    }

                    int targetCharacterIndex = 0;

                    for (int j = i; j < builder.Length; j++, targetCharacterIndex++)
                    {
                        if (targetCharacterIndex == target.Length)
                        {
                            break;
                        }

                        if (char.ToLower(builder[j]) != char.ToLower(target[targetCharacterIndex]))
                        {
                            isFound = false;
                            break;
                        }
                    }

                    if (isFound)
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    char startChar = builder[i];
                    isFound = true;

                    if (startChar != target[0])
                    {
                        continue;
                    }

                    int targetCharacterIndex = 0;

                    for (int j = i; j < builder.Length; j++, targetCharacterIndex++)
                    {
                        if (targetCharacterIndex == target.Length)
                        {
                            break;
                        }

                        if (builder[j] != target[targetCharacterIndex])
                        {
                            isFound = false;
                            break;
                        }
                    }

                    if (isFound)
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        private static int HelperIndexOfCharacter(StringBuilder builder, char target, int start, int end)
        {
            int index = -1;

            for (int i = start; i <= end; i++)
            {
                if (builder[i] == target)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

    }
}