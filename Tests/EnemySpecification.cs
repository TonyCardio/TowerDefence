using System;
using System.Collections.Generic;
using NUnit.Framework;
using TowerDefence.Domain;
using FluentAssertions;
using System.Drawing;

namespace TowerDefence.Tests
{
    [TestFixture]
    class CreatEnemy
    {
        private List<Point> pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
        private Enemy enemy;
        [Test]
        public void CreateHighSkeletonWithCorrectPath_CheckProperties()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            enemy = new HighSkeleton(pathSpawnToCastle);
            enemy.Health.Should().Be(30);
            enemy.PunchPower.Should().Be(10);
            enemy.Speed.Should().Be(1);
        }

        [Test]
        public void CreateShortSkeletonWithCorrectPath_CheckProperties()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            enemy = new ShortSkeleton(pathSpawnToCastle);
            enemy.Health.Should().Be(25);
            enemy.PunchPower.Should().Be(5);
            enemy.Speed.Should().Be(2);
        }

        [Test]
        public void CreateGreenMonsterWithCorrectPath_CheckProperties()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            enemy = new GreenMonster(pathSpawnToCastle);
            enemy.Health.Should().Be(20);
            enemy.PunchPower.Should().Be(5);
            enemy.Speed.Should().Be(2);
        }


        [Test]
        public void CorrectStartPosition()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1)};
            enemy = new HighSkeleton(pathSpawnToCastle);
            enemy.Position.Should().Be(new Point(0, 0));
        }

        [Test]
        public void MoveEnemyToCastle()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 1) };
            enemy = new GreenMonster(pathSpawnToCastle);
            enemy.Move();
            enemy.IsAtCastle().Should().BeTrue();
        }

        [Test]
        public void EmemyIsLife_whenHeWasCreate()
        {
            pathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
            enemy = new ShortSkeleton(pathSpawnToCastle);
            enemy.IsLife().Should().BeTrue();
        }
    }
}
