namespace FurnitureManufacturer.Common
{
    using System;

    internal static class Validator
    {
        internal static void ValidateIfDecimalIsPositive(decimal value, string propertyName)
        {
            if (value <= 0.0m)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessages.NotPositiveDecimal, propertyName));
            }
        }

        internal static void ValidateIfStringIsNotNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(string.Format(GlobalErrorMessages.NullOrEmptyString, propertyName));
            }
        }

        internal static void ValidateStringMinLength(string value, int minLength, string propertyName)
        {
            if (value.Length < minLength)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessages.InvalidStringLength, propertyName, minLength));
            }
        }

        internal static void ValidateStringExactLength(string value, int exactLength, string propertyName)
        {
            if (value.Length != exactLength)
            {
                throw new ArgumentException(string.Format(GlobalErrorMessages.StringExactLength, propertyName, exactLength));
            }
        }

        internal static void ValidateIfObjectIsNotNull(object value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(string.Format(GlobalErrorMessages.NullObject, propertyName));
            }
        }
    }
}