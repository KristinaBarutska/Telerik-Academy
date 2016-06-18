namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Common;
    using FurnitureManufacturer.Interfaces;

    internal class Company : ICompany
    {
        private const int MinNameLength = 5;
        private const int ExactLengthOfRegNumber = 10;
        private const string InvalidNameLengthErrorMessage =
            "Company name length cannot be less than 5 characters long!";
        private const string InvalidRegNumberLengthErrorMessage =
            "Registration number must be exactly 10 characters long!";
        private const string NotOnlyDigitsErrorMessage = "Registration number must contain only digits!";

        private string name;
        private string registrationNumber;

        internal Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                string propertyName = "Company name";

                Validator.ValidateIfStringIsNullOrEmpty(value, propertyName);
                this.ValidateNameLength(value);
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                string propertyName = "Company registration number";

                Validator.ValidateIfStringIsNullOrEmpty(value, propertyName);
                this.ValidateExactLengthOfRegNumber(value);
                this.ValidateIfRegNumHasOnlyDigits(value);
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            Validator.ValidateIfFurnitureIsNull(furniture);
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            Validator.ValidateIfFurnitureIsNull(furniture);
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model == model);
        }

        public string Catalog()
        {
            this.Furnitures = this.Furnitures
                .OrderBy(f => f.Price)
                .ThenBy(f => f.Model)
                .ToList();

            var result = new StringBuilder();

            result.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            foreach (var furniture in this.Furnitures)
            {
                if (furniture.GetType().Name == "Chair" || furniture.GetType().Name == "AdjustableChair")
                {
                    result.AppendLine(furniture.ToString().Trim());
                }
                else
                {
                    result.Append(furniture.ToString().Trim());
                }
            }

            return result.ToString().Trim();
        }

        private void ValidateNameLength(string name)
        {
            if (name.Length < Company.MinNameLength)
            {
                throw new ArgumentException(Company.InvalidNameLengthErrorMessage);
            }
        }

        private void ValidateExactLengthOfRegNumber(string registrationNumber)
        {
            if (registrationNumber.Length != Company.ExactLengthOfRegNumber)
            {
                throw new ArgumentException(Company.InvalidRegNumberLengthErrorMessage);
            }
        }

        private void ValidateIfRegNumHasOnlyDigits(string registrationNumber)
        {
            if (registrationNumber.Any(t => !char.IsDigit(t)))
            {
                throw new ArgumentException(Company.NotOnlyDigitsErrorMessage);
            }
        }
    }
}