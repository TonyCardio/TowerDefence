using System;
using System.Collections.Generic;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;
using System.Drawing;

namespace Tests
{
    [TestFixture]
    class LevelLoaderSpecification
    {
        private string[] validLines;
        private string[] invalidLines;
        private Point castlePos;
        private Point spawnPos;
        private int wavesCount;
        private string name;

        [SetUp]
        public void SetUp()
        {
            name = "level";
            validLines = new[] { "000\r\n321\r\n000\r\n", "1" };
            wavesCount = int.Parse(validLines[1]);
            castlePos = new Point(0, 1);
            spawnPos = new Point(2, 1);
            invalidLines = new[] { "000\r\n-500\r\n000", "1" };
            validLines = new[] { "000\r\n321\r\n000\r\n", "1" };
        }

        [Test]
        public void LoadLevelFromLines_ShouldLoadLevel_WhenLinesAreOK()
        {
            var level = LevelsLoader.LoadLevelFromLines(validLines, name);
            level.Name.Should().Be(name);
            level.WavesCount.Should().Be(wavesCount);
            level.Field.CastlePos.Should().Be(castlePos);
            level.Field.EnemySpawnPos.Should().Be(spawnPos);
        }

        [Test]
        public void LoadLevelFromLines_ShouldThrowException_WhenLinesAreInvalid()
        {
            Action action = () => LevelsLoader.LoadLevelFromLines(invalidLines, name);
            action.Should().Throw<ArgumentException>();
        }

        [TestCase(new[] { "000\r\n323\r\n000\r\n", "1" }, "twoCastles")]
        [TestCase(new[] { "000\r\n121\r\n000\r\n", "1" }, "twoSpawns")]
        public void LoadLevelFromLines_ShouldThrowException_WhenMoreOneCastleOrEnemySpawn(string[] lines, string levelName)
        {
            Action action = () => LevelsLoader.LoadLevelFromLines(lines, levelName);
            action.Should().Throw<ArgumentException>();
        }
    }
}
