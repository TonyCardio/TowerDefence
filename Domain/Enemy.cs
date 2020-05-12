using System.Collections.Generic;
using System.Drawing;
using System;

namespace TowerDefence.Domain
{
    public class PositionChangingArgs : EventArgs
    {
        public Direction Direction;
        public Point CurrentPosition;
    }
    public class Enemy : IEnemy, ICreature
    {
        public delegate void PositionChangingHandler(PositionChangingArgs args);
        public event PositionChangingHandler PositionChanging;
        public event Action PathSpawnToCastlePassed;

        public void OnPositionChanging(PositionChangingArgs args)
        {
            if (PositionChanging != null) PositionChanging(args);
        }

        public void OnPathSpawnToCastlePassed()
        {
            if (PathSpawnToCastlePassed != null)
                PathSpawnToCastlePassed();
        }
       
        public int Health { get; set; }

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

        public bool IsLife() => Health > 0;

        public bool IsAtCastle() => (currentIndexOfPath == PathSpawnToCastle.Count - 1);

        public MovingCommand Act(int x, int y)
        {
            Direction direction = Direction.Stay;
            if (!IsAtCastle())
                currentIndexOfPath++;
            else
            {
                OnPathSpawnToCastlePassed(); //The enemy came to the castle
                return new MovingCommand() { direction = direction, DeltaX = 0, DeltaY = 0 };
            }
            var deltaPoint = new Point(PathSpawnToCastle[PathSpawnToCastle.Count - currentIndexOfPath].X - x,
                PathSpawnToCastle[PathSpawnToCastle.Count - currentIndexOfPath].Y - y);
            if (deltaPoint.X == 1) direction = Direction.Right;
            if (deltaPoint.X == -1) direction = Direction.Left;
            if (deltaPoint.Y == 1) direction = Direction.Up;
            if (deltaPoint.Y == -1) direction = Direction.Down;
            // OnPositionChanging(new PositionChangingArgs { CurrentPosition = Position, Direction = direction }); //Happened event of move Enemy
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
