namespace Infestation
{
    internal class PowerCatalyst : Suplement
    {
        private const int InitialAggressionEffect = 0;
        private const int InitialHealthEffect = 0;
        private const int InitialPowerEffect = 3;

        internal PowerCatalyst()
            : base(InitialAggressionEffect, InitialHealthEffect, InitialPowerEffect)
        {
        }
    }
}