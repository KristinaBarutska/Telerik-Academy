namespace ArmyOfCreatures.Tests
{
    using System;

    using NUnit.Framework;
    using Logic.Battles;
    using Logic.Creatures;
    using Extended.Creatures;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void Constructor_PassValidCreatureAndCount_ShouldSetCreatureToThisCreature()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.AreEqual(creature, creaturesInBattle.Creature);
        }

        [Test]
        public void Constructor_PassValidCreatureAndCount_ShouldSetCreatureAttackToPermanentAttack()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.AreEqual(creature.Attack, creaturesInBattle.PermanentAttack);
        }

        [Test]
        public void Constructor_PassValidCreatureAndCount_ShouldSetCreatureDefenseToPermanentDefense()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.AreEqual(creature.Defense, creaturesInBattle.PermanentDefense);
        }

        [Test]
        public void Constructor_PassValidCreatureAndCount_ShouldSetCreatureHealthPointsMultipliedByCounterToTotalHitPoints()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 2);

            Assert.AreEqual(creature.HealthPoints * 2, creaturesInBattle.TotalHitPoints);
        }

        [Test]
        public void TotalHitPoints_SetNegativeValue_GetShouldReturnZero()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 2);

            creaturesInBattle.TotalHitPoints = -100;

            Assert.AreEqual(0, creaturesInBattle.TotalHitPoints);
        }

        [Test]
        public void Count_ValidTotalHitPoints_ShouldReturn1For1Creature()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.AreEqual(1, creaturesInBattle.Count);
        }

        [Test]
        public void Count_TotalHitPointsLessThanCreatureHealthPoints_ShouldReturn0()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.TotalHitPoints = -1;
            Assert.AreEqual(0, creaturesInBattle.Count);
        }

        [Test]
        public void DealDamage_NullDefender_ShouldThrowArgumentNullException()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            Assert.Throws(typeof(ArgumentNullException), () => creaturesInBattle.DealDamage(null));
        }

        [Test]
        public void DealDamage_ValidDefender_ShouldDecreaseDefendersTotalHitPoints()
        {
            var attacker = new Angel();
            var defender = new Goblin();
            var creaturesInBattleAttacker = new CreaturesInBattle(attacker, 1);
            var creaturesInBattleDefender = new CreaturesInBattle(defender, 1);
            int oldTotalHitPoints = creaturesInBattleDefender.TotalHitPoints;

            creaturesInBattleAttacker.DealDamage(creaturesInBattleDefender);
            Assert.IsTrue(oldTotalHitPoints > creaturesInBattleDefender.TotalHitPoints);
        }

        [Test]
        public void Skip_ShouldAdd3PointsToPermanentDefense()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);
            int oldPermanentDefense = creaturesInBattle.PermanentDefense;

            creaturesInBattle.Skip();
            Assert.IsTrue(creaturesInBattle.PermanentDefense - oldPermanentDefense == 3);
        }

        [Test]
        public void StartNewTurn_ShouldSetPermanentAttackToCurrentAttack()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.StartNewTurn();
            Assert.AreEqual(creaturesInBattle.PermanentAttack, creaturesInBattle.CurrentAttack);
        }

        [Test]
        public void StartNewTurn_ShouldSetPermanentDefenseToCurrentDefense()
        {
            var creature = new Angel();
            var creaturesInBattle = new CreaturesInBattle(creature, 1);

            creaturesInBattle.StartNewTurn();
            Assert.AreEqual(creaturesInBattle.PermanentDefense, creaturesInBattle.CurrentDefense);
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