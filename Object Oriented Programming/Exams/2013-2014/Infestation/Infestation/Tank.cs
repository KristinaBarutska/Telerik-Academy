namespace Infestation
{
    internal class Tank : Unit
    {
        private const int InitialPower = 25;
        private const int InitialHealth = 20;
        private const int InitialAgression = 25;

        public Tank(string id)
            : base(id, UnitClassification.Mechanical, InitialHealth, InitialPower, InitialAgression)
        {
        }
    }
}