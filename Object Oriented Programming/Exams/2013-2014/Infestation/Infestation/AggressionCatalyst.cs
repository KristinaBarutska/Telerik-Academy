namespace Infestation
{
    internal class AggressionCatalyst : Suplement
    {
        private const int InitialAggressionEffect = 3;
        private const int InitialHealthEffect = 0;
        private const int InitialPowerEffect = 0;

        internal AggressionCatalyst() 
            : base(InitialAggressionEffect, InitialHealthEffect, InitialPowerEffect)
        {
        }
    }
}