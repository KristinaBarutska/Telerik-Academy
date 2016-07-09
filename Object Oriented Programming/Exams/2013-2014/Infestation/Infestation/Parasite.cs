namespace Infestation
{
    internal class Parasite : Infester
    {
        private const int BaseStat = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, BaseStat, BaseStat, BaseStat)
        {
        }
    }
}