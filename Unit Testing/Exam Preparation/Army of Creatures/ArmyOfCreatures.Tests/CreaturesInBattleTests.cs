namespace ArmyOfCreatures.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;
    using Logic.Creatures;
    using Logic.Battles;
    using Extended.Creatures;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void Constructor_ValidCreatureAndCount_ShouldInitializeAllProperties()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.IsTrue(
                creaturesInBattle.Creature == creature &&
                creaturesInBattle.PermanentAttack == creature.Attack &&
                creaturesInBattle.PermanentDefense == creature.Defense &&
                creaturesInBattle.TotalHitPoints == creature.HealthPoints);
        }

        [Test]
        public void TotalHitPoints_IfLessThan0ShouldReturn0()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.TotalHitPoints = -10;
            Assert.AreEqual(0, creaturesInBattle.TotalHitPoints);
        }

        [Test]
        public void Count_IfLessThan0ShouldReturn0()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.TotalHitPoints = 0;
            Assert.AreEqual(0, creaturesInBattle.Count);
        }

        [Test]
        public void DealDamage_NullDefender_ShouldThrowArgumentNullException()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.Throws<ArgumentNullException>(() => creaturesInBattle.DealDamage(null));
        }

        [Test]
        public void DealDamage_ValidDefender_DefendersTotalHitPointsShouldBeReduced()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            var defenderCreature = new Goblin();
            var defender = new CreaturesInBattle(defenderCreature, 1);
            var notModifiedDefendersHitPoints = defender.TotalHitPoints;

            creaturesInBattle.DealDamage(defender);
            Assert.IsTrue(defender.TotalHitPoints < notModifiedDefendersHitPoints);
        }

        [Test]
        public void Skip_ShouldIncreasePermanentDefenseBy3()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            var notModifiedPermanentDefense = creaturesInBattle.PermanentDefense;

            creaturesInBattle.Skip();
            Assert.AreEqual(notModifiedPermanentDefense + 3, creaturesInBattle.PermanentDefense);
        }

        [Test]
        public void StartNewTurn_ShouldSetCurrentAttackToPermanentAttack()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.StartNewTurn();
            Assert.AreEqual(creaturesInBattle.CurrentAttack, creaturesInBattle.PermanentAttack);
        }

        [Test]
        public void StartNewTurn_ShouldSetCurrentDefenseToPermanentDefense()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.StartNewTurn();
            Assert.AreEqual(creaturesInBattle.CurrentDefense, creaturesInBattle.PermanentDefense);
        }

        [Test]
        public void StartNewTurn_ShouldSetLastDamageTo0()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.StartNewTurn();

            var lastDamage = (decimal)typeof(CreaturesInBattle)
                .GetField("lastDamage", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(creaturesInBattle);

            Assert.AreEqual(0, lastDamage);
        }

        [Test]
        public void ToString_ShouldReturnProperInformationAboutTheCreaturesInBattle()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            string expected = $"{creaturesInBattle.Count} {creaturesInBattle.Creature.GetType().Name} " +
                $"(ATT:{creaturesInBattle.CurrentAttack}; DEF:{creaturesInBattle.CurrentDefense}; " +
                $"THP:{creaturesInBattle.TotalHitPoints}; LDMG:{0})";
            string actual = creaturesInBattle.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}