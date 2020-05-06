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
        private List<Point> CorrectPathSpawnToCastle = new List<Point>() { new Point(0, 0), new Point(0, 1) };
        private Enemy enemy;
        [Test]
        public void CreateHighSkeletonWithCorrectPath_CheckProperties()
        {
            enemy = new HighSkeleton(CorrectPathSpawnToCastle);
            enemy.Health.Should().Be(30);
            enemy.PunchPower.Should().Be(10);
            enemy.Speed.Should().Be(1);
        }

        [Test]
        public void CreateShortSkeletonWithCorrectPath_CheckProperties()
        {
            enemy = new ShortSkeleton(CorrectPathSpawnToCastle);
            enemy.Health.Should().Be(25);
            enemy.PunchPower.Should().Be(5);
            enemy.Speed.Should().Be(2);
        }

        [Test]
        public void CreateGreenMonsterWithCorrectPath_CheckProperties()
        {
            enemy = new GreenMonster(CorrectPathSpawnToCastle);
            enemy.Health.Should().Be(20);
            enemy.PunchPower.Should().Be(5);
            enemy.Speed.Should().Be(2);
        }


        [Test]
        public void CorrectStartPosition()
        {
            enemy = new HighSkeleton(CorrectPathSpawnToCastle);
            enemy.Position.Should().Be(new Point(0, 0));
        }

        [Test]
        public void MoveEnemyToCastle()
        {
            enemy = new GreenMonster(CorrectPathSpawnToCastle);
            enemy.Move();
            enemy.IsAtCastle().Should().BeTrue();
        }

        [Test]
        public void EmemyIsLife_whenHeWasCreated()
        {
            enemy = new ShortSkeleton(CorrectPathSpawnToCastle);
            enemy.IsLife().Should().BeTrue();
        }
    }
}
