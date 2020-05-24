using System;
using System.Collections.Generic;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;
using System.Drawing;

namespace TowerDefence.Tests
{
    [TestFixture]
    class BulletSpecification
    {
        private string[] validLines;
        private Level level;
        private FieldState state;
        private Bullet bullet;

        [SetUp]
        public void SetUp()
        {
            validLines = new[] { "000000\r\n322221\r\n000000\r\n", "1" };
            level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            Game.CurrentLevel = level;
            state = new FieldState(level.Field);
            bullet = new Bullet(Direction.Up);
            level.Field.Cells[1, 0].Creature = bullet;
        }

        [Test]
        public void BulletMakeCorrectStep()
        {
            state.BeginAct();
            state.EndAct();
            (level.Field.Cells[1, 1].Creature is Bullet).Should().BeTrue();
        }

        [Test]
        public void BulletDestroyedWhenGoesBeyondMap()
        {
            for(var i= 0; i<3; i++)
            {
                state.BeginAct();
                state.EndAct();
            }
            bullet.IsAlive.Should().BeFalse();
        }
    }
}
