namespace WarMachines.Common
{
    using System;

    internal static class Validator
    {
        internal static void ValidateDouble(double value, string propertyName)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessages.NegativeDouble, propertyName));
            }
        }

        internal static void ValidateString(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(GlobalErrorMessages.NullOrEmptyString, propertyName));
            }
        }

        internal static void ValidateObject(object objectToValidate, string propertyName)
        {
            if (objectToValidate == null)
            {
                throw new ArgumentNullException(string.Format(GlobalErrorMessages.NullObject, propertyName));
            }
        }
    }
}