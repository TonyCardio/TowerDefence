using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class Bullet : ICreature
    {
        public static int Damage { get; } = 5;
        public int CountFlightCompletedPossition { get; set; }
        public Direction ShotDirection { get; set; }

        public event Action DeleteBullet;

        public void OnDeleteBullet()
        {
            if (DeleteBullet != null) DeleteBullet();
        }

        public Bullet(Direction direction)
        {
            ShotDirection = direction;
        }

        
        public MovingCommand Act(int x, int y)
        {
            var height = Game.CurrentLevel.Field.Height;
            var width = Game.CurrentLevel.Field.Width;
            var offsetPoint = new Point();
            if (CountFlightCompletedPossition < 5)
            {
                if (ShotDirection == Direction.Up)
                    if (y + 1 < height)
                        offsetPoint.Y = 1;
                    else
                    {
                        offsetPoint.Y = 0;
                        OnDeleteBullet();
                    }
                if (ShotDirection == Direction.Left)
                    if (x > 0)
                        offsetPoint.X = -1;
                    else
                    {
                        offsetPoint.X = 0;
                        OnDeleteBullet();
                    }
                CountFlightCompletedPossition++;
            }
            else
                OnDeleteBullet();
          
            return new MovingCommand() { DeltaX = offsetPoint.X, DeltaY = offsetPoint.Y, direction = ShotDirection};
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            return () =>
            {
                if (conflictedObject is Enemy)
                    conflictedObject.ActionInConflict(this)();
            };
        }

        public bool IsAlive() => true;
    }
}
