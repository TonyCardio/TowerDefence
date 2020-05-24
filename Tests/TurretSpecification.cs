using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;
using System.Drawing;

namespace TowerDefence.Tests
{
    [TestFixture]
    class TurretSpecification
    {
        private string[] validLines;
        private Level level;
        private FieldState state;
        private Turret horizontalturret;

        [SetUp]
        public void SetUp()
        {
            validLines = new[] { "00000\r\n32221\r\n00000\r\n", "1" };
            level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            Game.CurrentLevel = level;
            state = new FieldState(level.Field);
            horizontalturret = new HorizontalTurret(level.Field);
            level.Field.PutTurret(horizontalturret, new Point(3, 0));
        }

        [Test]
        public void CorrectTurretShot()
        {
            state.BeginAct();
            state.EndAct();
            (level.Field.Cells[2, 0].Creature is Bullet).Should().BeTrue();
        }
    }
}
