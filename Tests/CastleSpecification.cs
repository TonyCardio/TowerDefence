using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Domain;

namespace TowerDefence.Tests
{
    [TestFixture]
    class CastleSpecification
    {
         [Test]
         public void CastleIsNotDestroyed_whenItCreated()
        {
            var castle = new Castle();
            castle.IsAlive.Should().BeFalse();
        }

        [Test]
        public void DestroyCustle()
        {
            var castle = new Castle();
            var pathSpawnToCastle = new List<Point> { new Point(0, 0), new Point(0, 1), new Point(1, 1) };
            var enemy = new HighSkeleton(pathSpawnToCastle);
            for(var i=0; i< 10; i++)
            {
                castle.ActionInConflict(enemy)();
            }
            castle.Health.Should().Be(0);
            castle.IsAlive.Should().BeTrue();
        }
    }
}
