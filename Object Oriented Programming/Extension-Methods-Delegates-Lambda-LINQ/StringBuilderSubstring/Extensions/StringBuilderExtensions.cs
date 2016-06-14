namespace StringBuilderSubstring.Extensions
{
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int start, int length)
        {
            StringBuilder result = new StringBuilder();

            for (int i = start; i <= start + length; i++)
            {
                result.Append(sb[i]);
            }

            return result;
        }
    }
}