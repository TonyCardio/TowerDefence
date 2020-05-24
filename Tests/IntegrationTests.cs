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
    public class IntegrationTests
    {
        private string[] validLines;
        private Level level;
        private Point spawn;
        private FieldState state;

        [SetUp]
        public void SetUp()
        {
            validLines = new[] { "000\r\n321", "1" };
            level = LevelsLoader.LoadLevelFromLines(validLines, "Level");
            Game.CurrentLevel = level;
            spawn = level.Field.EnemySpawnPos;
            state = new FieldState(level.Field);
        }

        [Test]
        public void Game_ShouldBeLost_WhenCastleDestroyed()
        {
            for (int i = 0; i < 20; i++)
            {
                level.Field.Cells[spawn.X, spawn.Y].Creature = new HighSkeleton(level.PathSpawnToCastle);
                state.BeginAct();
                state.EndAct();
                state.BeginAct();
                state.EndAct();
            }
            level.IsLost.Should().Be(true);
            Game.Stage.Should().Be(GameStage.Finished);
        }

        [Test]
        public void Game_ShouldBeWon_WhenAllEnemiesDied()
        {
            var monster = new GreenMonster(level.PathSpawnToCastle);
            monster.IsLastInlevel = true;
            monster.Health = 1;
            level.Field.Cells[1, 0].Creature = new Bullet(Direction.Up);
            level.Field.Cells[spawn.X, spawn.Y].Creature = monster;
            state.BeginAct();
            state.EndAct();
            state.BeginAct();
            state.EndAct();
            level.IsLost.Should().Be(false);
            Game.Stage.Should().Be(GameStage.Finished);
        }
    }
}