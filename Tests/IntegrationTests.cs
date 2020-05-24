using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;

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
            level.EnemiesPerWave = 1;
            level.Field.Cells[spawn.X, spawn.Y].Creature = monster;
            state.BeginAct();
            state.EndAct();
            monster.Position.Should().Be(level.PathSpawnToCastle[1]);
        }
    }
}