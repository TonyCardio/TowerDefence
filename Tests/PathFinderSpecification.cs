using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TowerDefence.Domain;

namespace TowerDefence.Tests
{
    [TestFixture]
    class PathFinderSpecification
    {
        private string[] validLines;
        private string[] invalidLines;

        [SetUp]
        public void SetUp()
        {
            validLines = new[] { "000\r\n321\r\n000\r\n", "1" };
            invalidLines = new[] { "0000\r\n3021\r\n0000\r\n", "1" };
        }

        [Test]
        public void CreateEnemysPath_ShouldFindPath_WhenExists()
        {
            var expexted = new List<Point>()
            {
                new Point(2,1),
                new Point(1,1),
                new Point(0,1)
            };
            var level = LevelsLoader.LoadLevelFromLines(validLines, "TestLevel");
            level.PathSpawnToCastle.Should().BeEquivalentTo(expexted);
        }

        [Test]
        public void CreateEnemysPath_ShouldThrowException_WhenNotExists()
        {
            Action action = () => LevelsLoader.LoadLevelFromLines(invalidLines, "TestLevel");
            action.Should().Throw<ArgumentException>();
        }
    }
}
