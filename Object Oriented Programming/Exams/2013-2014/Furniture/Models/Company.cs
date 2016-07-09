namespace FurnitureManufacturer.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Common;
    using FurnitureManufacturer.Interfaces;

    internal class Company : ICompany
    {
        private const int CompanyMinNameLength = 5;
        private const int CompanyExactRegNumberLength = 10;
        private const string CompanyName = "Company name";
        private const string CompanyRegistrationNumber = "Company registration number";
        private const string FurnitureToAdd = "The furniture that will be added to company's furnitures";
        private const string CompanyInfoFormatString = "{0} - {1} - {2} {3}";
        private const string NoFurnitures = "no";
        private const string SingleFurnitute = "furniture";
        private const string ZeroOrMoreThanOneFurnitures = "furnitures";
        private const string ChairType = "Chair";
        private const string AdjustableChairType = "AdjustableChair";

        private string name;
        private string registrationNumber;

        internal Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures
        {
            get; private set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateIfStringIsNotNullOrEmpty(value, CompanyName);
                Validator.ValidateStringMinLength(value, CompanyMinNameLength, CompanyName);
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
                Validator.ValidateIfStringIsNotNullOrEmpty(value, CompanyRegistrationNumber);
                Validator.ValidateStringExactLength(value, CompanyExactRegNumberLength, CompanyRegistrationNumber);
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            Validator.ValidateIfObjectIsNotNull(furniture, FurnitureToAdd);
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            this.Furnitures = this.Furnitures
                .OrderBy(f => f.Price)
                .ThenBy(f => f.Model)
                .ToList();

            var result = new StringBuilder();
            string furnituresCount = this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : NoFurnitures;
            string furnituresCountString = this.Furnitures.Count != 1 ? ZeroOrMoreThanOneFurnitures : SingleFurnitute;

            result.AppendLine(string.Format(CompanyInfoFormatString, this.Name, this.RegistrationNumber,
                furnituresCount, furnituresCountString));

            foreach (var furniture in this.Furnitures)
            {
                result.AppendLine(furniture.ToString());
            }

            return result.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}