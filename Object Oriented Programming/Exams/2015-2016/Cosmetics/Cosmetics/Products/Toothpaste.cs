namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Contracts;
    using Common;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinIngredientLength = 4;
        private const int MaxIngredientLength = 12;
        private const string EachIngredient = "Each ingredient";

        public Toothpaste(string brand, GenderType gender, string name, decimal price, IList<string> ingredients)
            : base(brand, gender, name, price)
        {
            this.ValidateIngredients(ingredients);
            this.Ingredients = string.Join(", ", ingredients);
        }

        public string Ingredients
        {
            get; private set;
        }

        public override string Print()
        {
            var result = new StringBuilder(base.Print());

            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString().Trim();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, MaxIngredientLength, MinIngredientLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, EachIngredient, MinIngredientLength, MaxIngredientLength));
            }
        }
    }
}