namespace Infestation
{
    internal class Queen : Infester
    {
        private const int BaseHealth = 30;
        private const int BasePower = 1;
        private const int BaseAgression = 1;

        public Queen(string id) 
            : base(id, UnitClassification.Psionic, BaseHealth, BasePower, BaseAgression)
        {
        }
    }
}