namespace Infestation
{
    internal class Weapon : Suplement
    {
        private const int InitialAggressionEffect = 0;
        private const int InitialHealthEffect = 0;
        private const int InitialPowerEffect = 0;
        private const int WeaponarySkillPowerEffect = 10;
        private const int WeaponarySkillAggressionEffect = 3;

        internal Weapon()
            : base(InitialAggressionEffect, InitialHealthEffect, InitialPowerEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement as WeaponrySkill != null)
            {
                this.AggressionEffect = WeaponarySkillAggressionEffect;
                this.PowerEffect = WeaponarySkillPowerEffect;
            }
        }
    }
}