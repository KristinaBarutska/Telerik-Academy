namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;


    internal class Toothpaste : Product, IToothpaste
    {
        private const string EachIngredient = "Each ingredient";
        private const string IngredientString = "Ingredient";
        private const string IngredientsSeparator = ", ";
        private const int MinIngredientLength = 4;
        private const int MaxIngredientLength = 12;

        internal Toothpaste(string brand, GenderType gender, string name, decimal price, IList<string> ingredients)
            : base(brand, gender, name, price)
        {
            this.ValidateIngredients(ingredients);
            this.Ingredients = string.Join(IngredientsSeparator, ingredients);
        }

        public string Ingredients
        {
            get; private set;
        }

        public override string Print()
        {
            var result = new StringBuilder(base.Print());

            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));
            return result.ToString();
        }

        private void ValidateIngredients(ICollection<string> ingredients)
        {
            Validator.CheckIfNull(ingredients, string.Format(GlobalErrorMessages.ObjectCannotBeNull, EachIngredient));

            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientLength, MinIngredientLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, EachIngredient, MinIngredientLength, MaxIngredientLength));
                Validator.CheckIfStringIsNullOrEmpty(ingredient,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, IngredientString));
            }
        }
    }
}