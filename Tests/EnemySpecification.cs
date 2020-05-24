using System;
using System.Collections.Generic;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;
using System.Drawing;

namespace TowerDefence.Tests
{
    [TestFixture]
    class CreateEnemy
    {
        private string[] validLines;
        private Level level;
        private Point spawnPos;
        private FieldState state;
        private GreenMonster monster;

        [SetUp]
        public void SetUp()
        {
            validLines = new[] { "000\r\n321\r\n000\r\n", "1" };
            level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            state = new FieldState(level.Field);
            spawnPos = level.Field.EnemySpawnPos;
            monster = new GreenMonster(level.PathSpawnToCastle);
            level.Field.Cells[spawnPos.X, spawnPos.Y].Creature = monster;
        }

        [Test]
        public void EnemyReachesCastleAndDies()
        {
            for(int i = 0; i < level.PathSpawnToCastle.Count; i++)
            {
                state.BeginAct();
                state.EndAct();
            }
            monster.IsAtCastle().Should().BeTrue();
            monster.IsAlive.Should().BeFalse();
        }

        [Test]
        public void CorrectStartPosition()
        {
            monster.Position.Should().Be(spawnPos);
        }
    }
}
