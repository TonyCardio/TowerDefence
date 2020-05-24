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
    class IntegrationTests
    {
        [Test]
        public void Test()
        {
            var validLines = new[] { "000\r\n321\r\n000\r\n", "1" };
            var level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            var state = new FieldState(level.Field);
            var spawn = level.Field.EnemySpawnPos;
            var monster = new GreenMonster(level.PathSpawnToCastle);
            level.Field.Cells[spawn.X, spawn.Y].Creature = monster;
            state.BeginAct();
            state.EndAct();
            monster.Position.Should().Be(level.PathSpawnToCastle[1]);
        }

        [Test]
        public void Test2()
        {
            var validLines = new[] { "00000\r\n32221\r\n00000\r\n", "1" };
            var level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            Game.CurrentLevel = level;
            var state = new FieldState(level.Field);
            var turret = new HorizontalTurret();
            level.Field.PutTurret(turret, new Point(4, 0));
            state.BeginAct();
            state.EndAct();
        }
    }
}