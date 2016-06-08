namespace MobileDevices
{
    using System;

    public static class ValueValidator
    {
        public static void ValidateStringValue(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format("Invalid {0}. It cannot be null or empty string!", propertyName));
            }
        }

        public static void ValidateIntegerValue(int value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid {0}. It cannot be less than or equals to 0!");
            }
        }

        public static void ValidateDoubleValue(double value, string propertyName)
        {
            if (value <= 0.0)
            {
                throw new ArgumentException("Invalid {0}. It cannot be less than or equals to 0!");
            }
        }

        public static void ValidateDecimalValue(decimal value, string propertyName)
        {
            if (value <= 0.0m)
            {
                throw new ArgumentException("Invalid {0}. It cannot be less than or equals to 0!");
            }
        }

        public static void ValidateObjectValue(object value, string propertyName)
        {
            if (value == null)
            {
                throw new ArgumentException(string.Format("Invalid {0}. It cannot be null!", propertyName));
            }
        }
    }
}