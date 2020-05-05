using System.Collections.Generic;
using System.Drawing;
using System;

namespace TowerDefence.Domain
{
   public class ShiftEventArgs : EventArgs
    {
        public Direction Direction { get; set; }
    }

    public delegate void ShiftEventHandler(object sender, ShiftEventArgs args);

    public class Enemy : IEnemy
    {
        public event ShiftEventHandler Shift;

        protected virtual void OnShift(object sender, ShiftEventArgs args)
        {
            if (Shift != null)            
                Shift(sender, args);            
        }
        public EnemyType Type { get; set; }

        public int Health { get; set; }

        public int PunchPower { get; set; }

        public float Speed { get; set; }

        public Point Position { get; set; }
        
        public List<Point> PathSpawnToCastle { get; set; } 

        public Enemy(List<Point> path, EnemyType type)
        {
            if (path is null || path.Count < 1)
                throw new ArgumentNullException("Incorrect path from spawn to castle");
            PathSpawnToCastle = path;
            Position = path[0];
            Type = type;
        }

        public bool IsLife() => Health > 0;

        public bool IsAtCastle() => (Position == PathSpawnToCastle[PathSpawnToCastle.Count - 1]);

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
                Position = PathSpawnToCastle[i];
                Shift(this, new ShiftEventArgs { Direction = direction});
            }
        }
    }
}
