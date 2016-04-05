namespace MobileDevice
{
    using System;

    public static class ValueValidator
    {
        public static void ValidateNumber(double numberValue, string nameOfObject)
        {
            if (numberValue < 0)
            {
                throw new ArgumentException("The value of " + nameOfObject + " cannot be less than 0.");
            }
        }

        public static void ValidateString(string stringValue, string nameOfObject)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new ArgumentException("The string value of " + nameOfObject + " cannot be null or empty.");
            }
        }
    }
}