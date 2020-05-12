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
        public int Damage { get; } = 5; 
        public Direction ShotDirection { get; set; }
        public Bullet(Direction direction)
        {
            ShotDirection = direction;
        }

        
        public MovingCommand Act(int x, int y)
        {
            var offsetPoint = new Point();
            if (ShotDirection == Direction.Up) offsetPoint.Y = 1;
            if (ShotDirection == Direction.Down) offsetPoint.Y = -1;
            if (ShotDirection == Direction.Right) offsetPoint.X = 1;
            if (ShotDirection == Direction.Left) offsetPoint.X = -1;
            return new MovingCommand();
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            throw new NotImplementedException();
        }
    }
}
