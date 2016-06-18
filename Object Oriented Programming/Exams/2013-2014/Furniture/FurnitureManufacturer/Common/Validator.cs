namespace FurnitureManufacturer.Common
{
    using System;

    using FurnitureManufacturer.Interfaces;

    internal static class Validator
    {
        private const string NegativeDecimalErrorMessage = "{0} cannot be less than or equal to 0.00!";
        private const string NullOrEmptyStringErrorMessage = "{0} cannot be null or empty string!";
        private const string NegativeIntegerErrorMessage = "{0} cannot be less than or equal to 0.00!";
        private const string NullFurnitureErrorMessage = "Furniture cannot be null!";

        internal static void ValidateIfDecimalValueIsPositive(decimal value, string propertyName)
        {
            if (value <= 0.0m)
            {
                throw new ArgumentException(string.Format(Validator.NegativeDecimalErrorMessage, propertyName));
            }
        }

        internal static void ValidateIfStringIsNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(String.Format(Validator.NullOrEmptyStringErrorMessage, propertyName));
            }
        }

        internal static void ValidateIfIntegerValuesIsPositive(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Validator.NegativeIntegerErrorMessage, propertyName));
            }
        }

        internal static void ValidateIfFurnitureIsNull(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new ArgumentNullException(Validator.NullFurnitureErrorMessage);
            }
        }
    }
}