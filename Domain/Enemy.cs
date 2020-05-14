using System.Collections.Generic;
using System.Drawing;
using System;

namespace TowerDefence.Domain
{
    public class Enemy : IEnemy, ICreature
    {
        public static event Action<int> PathSpawnToCastlePassed;

        public int Health { get; set; }

        public bool IsAlive() => Health > 0;

        public int PunchPower { get; set; }

        public int Speed { get; set; }

        public Point Position { get; set; }

        public List<Point> PathSpawnToCastle { get; set; }

        public int currentIndexOfPath { get; set; }

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

        public bool IsAtCastle() => (currentIndexOfPath == PathSpawnToCastle.Count - 1);

        public MovingCommand Act(int x, int y)
        {
            Direction direction = Direction.Stay;
            if (!IsAtCastle())
                currentIndexOfPath++;
            else
            {
                //PathSpawnToCastlePassed?.Invoke(PunchPower);
                return new MovingCommand() { direction = direction, DeltaX = 0, DeltaY = 0 };
            }
            var deltaPoint = new Point(PathSpawnToCastle[PathSpawnToCastle.Count - currentIndexOfPath].X - x,
                PathSpawnToCastle[PathSpawnToCastle.Count - currentIndexOfPath].Y - y);
            if (deltaPoint.X == 1) direction = Direction.Right;
            if (deltaPoint.X == -1) direction = Direction.Left;
            if (deltaPoint.Y == 1) direction = Direction.Up;
            if (deltaPoint.Y == -1) direction = Direction.Down;
            Position = PathSpawnToCastle[currentIndexOfPath];
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
