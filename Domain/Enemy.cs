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
        public int CountMoveLeftFrames { get; set; }
        public int CountMoveRightFrames { get; set; }
        public int CountMoveUpFrames { get; set; }
        public int CountMoveDownFrames { get; set; }
        public int Height { get; set; }
        public int Widht { get; set; }

        public int Health { get; set; }

        public int PunchPower { get; set; }

        public int Speed { get; set; }

        public Point Position { get; set; }

        public List<Point> PathSpawnToCastle { get; set; }

        public int currentIndexOfPath { get; set; }

        public Enemy(List<Point> path, int health, int punchPower, int speed,
            int countMoveLeftFrames, int countMoveRightFrames, int countMoveUpFrames,
            int countMoveDownFrames, int width, int height)
        {
            if (path is null || path.Count < 1)
                throw new Exception("Incorrect path from spawn to castle");

            PathSpawnToCastle = path;
            Position = path[0];
            Health = health;
            PunchPower = punchPower;
            Speed = speed;
            CountMoveDownFrames = countMoveDownFrames;
            CountMoveLeftFrames = countMoveLeftFrames;
            CountMoveRightFrames = countMoveRightFrames;
            CountMoveUpFrames = countMoveUpFrames;
            Height = height;
            Widht = width;
        }

        public bool IsLife() => Health > 0;

        public bool IsAtCastle() => (currentIndexOfPath == PathSpawnToCastle.Count - 1);

        public void MakeStep()
        {
            Direction direction = Direction.Stay;
            if (!IsAtCastle())
                currentIndexOfPath++;
            else
            {
                OnPathSpawnToCastlePassed(); //The enemy came to the castle
                return;
            }
            var deltaPoint = new PointF(PathSpawnToCastle[currentIndexOfPath].X - Position.X,
                PathSpawnToCastle[currentIndexOfPath].Y - Position.Y);
            if (deltaPoint.X == 1) direction = Direction.Right;
            if (deltaPoint.X == -1) direction = Direction.Left;
            if (deltaPoint.Y == 1) direction = Direction.Up;
            if (deltaPoint.Y == -1) direction = Direction.Down;
            OnPositionChanging(new PositionChangingArgs { CurrentPosition = Position, Direction = direction }); //Happened event of move Enemy
            Position = PathSpawnToCastle[currentIndexOfPath];
        }

        public MovingCommand Act(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            throw new NotImplementedException();
        }

        /*
        public void Move()
        {
            Direction direction = Direction.Stay;
            for (var i = 1; i < PathSpawnToCastle.Count; i++)
            {
                var deltaPoint = new PointF(PathSpawnToCastle[i].X - Position.X, PathSpawnToCastle[i].Y - Position.Y);
                if (deltaPoint.X == 1) direction = Direction.Right;
                if (deltaPoint.X == -1) direction = Direction.Left;
                if (deltaPoint.Y == 1) direction = Direction.Up;
                if (deltaPoint.Y == -1) direction = Direction.Down;
                OnPositionChanging(new PositionChangingArgs { CurrentPosition = Position, Direction = direction }); //Happened event of move Enemy
                Position = PathSpawnToCastle[i];
            }
        }
        May be useful in future 
        */
    }
}
