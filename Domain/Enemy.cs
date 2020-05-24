using System.Collections.Generic;
using System.Drawing;
using System;

namespace TowerDefence.Domain
{
    public class Enemy : IEnemy, ICreature
    {
        public int Health { get; set; }
        public bool IsAlive { get => Health > 0; set { } }
        public int PunchPower { get; set; }
        public int Speed { get; set; }
        public Point Position { get; set; }
        public List<Point> PathSpawnToCastle { get; set; }
        public int CurrentIndexOfPath { get; set; }

        //public static event Action<int> PathSpawnToCastlePassed;

        public Enemy(List<Point> path, int health, int punchPower, int speed)
        {
            if (path is null || path.Count < 1)
                throw new Exception("Incorrect path from spawn to castle");

            PathSpawnToCastle = path;
            Position = path[0];
            Health = health;
            PunchPower = punchPower;
            Speed = speed;
        }

        public bool IsAtCastle() => (CurrentIndexOfPath == PathSpawnToCastle.Count - 1);

        public MovingCommand Act(int x, int y)
        {
            Direction direction = Direction.Stay;
            if (!IsAtCastle())
                CurrentIndexOfPath++;
            else
            {
                //PathSpawnToCastlePassed?.Invoke(PunchPower);
                Health = 0;
                return new MovingCommand() { direction = direction, DeltaX = 0, DeltaY = 0 };
            }
            var pathPoint = PathSpawnToCastle[CurrentIndexOfPath];
            var deltaPoint = new Point(pathPoint.X - x, pathPoint.Y - y);
            if (deltaPoint.X == 1) direction = Direction.Right;
            if (deltaPoint.X == -1) direction = Direction.Left;
            if (deltaPoint.Y == 1) direction = Direction.Down;
            if (deltaPoint.Y == -1) direction = Direction.Up;
            Position = PathSpawnToCastle[CurrentIndexOfPath];
            return new MovingCommand
            {
                direction = direction,
                DeltaX = deltaPoint.X,
                DeltaY = deltaPoint.Y
            };
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            return () =>
            {
                Health -= (conflictedObject is Bullet) ? Bullet.Damage : 0;
            };
        }
    }
}
