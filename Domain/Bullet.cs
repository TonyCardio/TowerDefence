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
        public int TimeFlying { get; set; }
        public Direction ShotDirection { get; set; }
        public bool IsAlive { get; set; }

        public Bullet(Direction direction)
        {
            ShotDirection = direction;
            IsAlive = true;
        }

        private void Destroy() => IsAlive = false;

        public MovingCommand Act(int x, int y)
        {
            var height = Game.CurrentLevel.Field.Height;
            var width = Game.CurrentLevel.Field.Width;
            var offsetPoint = new Point();
            if (TimeFlying < 5)
            {
                if (ShotDirection == Direction.Up)
                    if (y + 1 < height)
                        offsetPoint.Y = 1;
                    else
                    {
                        offsetPoint.Y = 0;
                        Destroy();
                    }
                if (ShotDirection == Direction.Left)
                    if (x > 0)
                        offsetPoint.X = -1;
                    else
                    {
                        offsetPoint.X = 0;
                        Destroy();
                    }
                TimeFlying++;
            }
            else
                Destroy();

            return new MovingCommand()
            {
                DeltaX = offsetPoint.X,
                DeltaY = offsetPoint.Y,
                direction = ShotDirection
            };
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            return () =>
            {
                if (conflictedObject is Enemy)
                    Destroy();
            };
        }
    }
}
