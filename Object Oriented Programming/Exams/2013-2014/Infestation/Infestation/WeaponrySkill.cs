namespace Infestation
{
    internal class WeaponrySkill : Suplement
    {
        private const int InitalAgressionEffect = 0;
        private const int InitalHealthEffect = 0;
        private const int InitalPowerEffect = 0;

        internal WeaponrySkill()
            : base(InitalAgressionEffect, InitalHealthEffect, InitalPowerEffect)
        {
        }
    }
}