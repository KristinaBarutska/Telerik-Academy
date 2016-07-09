namespace Infestation
{
    internal class InfestationSpores : Suplement
    {
        private const int InitialAggressionEffect = 20;
        private const int InitialPowerEffect = -1;
        private const int InitalHealthEffect = 0;
        private const int Zero = 0;

        internal InfestationSpores()
            : base(InitialAggressionEffect, InitalHealthEffect, InitialPowerEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement as InfestationSpores != null)
            {
                this.AggressionEffect = Zero;
                this.PowerEffect = Zero;
            }
        }
    }
}