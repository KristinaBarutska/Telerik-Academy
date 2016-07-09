namespace FurnitureManufacturer.Common
{
    internal abstract class GlobalErrorMessages
    {
        internal const string NotPositiveDecimal = "{0} must be a positive number!";
        internal const string NullOrEmptyString = "{0} must not be null or empty!";
        internal const string InvalidStringLength = "{0} must be atleast {1} characters long!";
        internal const string StringExactLength = "{0} exact length must be {1} characters long!";
        internal const string NullObject = "{0} must not be a null!";
    }
}