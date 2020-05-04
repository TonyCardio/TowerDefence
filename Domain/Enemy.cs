using System.Collections.Generic;
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

        public List<Point> Path { get; set; }

        public Enemy(List<Point> path, EnemyType type)
        {
            if (path is null || path.Count < 1)
                throw new ArgumentNullException("Некорректный путь");
            Path = path;
            Position = path[0];
            Type = type;
        }

        public bool IsLife() => Health > 0;

        public bool IsAtCastle() => (Position == Path[Path.Count - 1]);

        public void Move()
        {
            Direction direction = Direction.Stay;
            for (var i = 1; i < Path.Count; i++)
            {
                var deltaPoint = Position - Path[i];
                if (deltaPoint.X == 1) direction = Direction.Right;
                if (deltaPoint.X == -1) direction = Direction.Left;
                if (deltaPoint.Y == 1) direction = Direction.Up;
                if (deltaPoint.Y == -1) direction = Direction.Down;
                Position = Path[i];
                Shift(this, new ShiftEventArgs { Direction = direction});
            }
        }
    }
}
