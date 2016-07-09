using System;

namespace Infestation
{
    internal abstract class Suplement : ISupplement
    {
        internal Suplement(int aggressionEffect, int healthEffect, int powerEffect)
        {
            this.AggressionEffect = aggressionEffect;
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
        }

        public int AggressionEffect
        {
            get; protected set;
        }

        public int HealthEffect
        {
            get; private set;
        }

        public int PowerEffect
        {
            get; protected set;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
            return;
        }
    }
}