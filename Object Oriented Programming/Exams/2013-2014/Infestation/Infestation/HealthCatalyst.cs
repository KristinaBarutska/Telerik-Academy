namespace Infestation
{
    internal class HealthCatalyst : Suplement
    {
        private const int InitialAggressionEffect = 0;
        private const int InitialHealthEffect = 3;
        private const int InitialPowerEffect = 0;

        internal HealthCatalyst()
            : base(InitialAggressionEffect, InitialHealthEffect, InitialPowerEffect)
        {
        }
    }
}