using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Domain;
using System.Drawing;

namespace TowerDefence.View
{
    class Animation
    {
        public Sprite Sprite;
        public ICreature Creature;
        public MovingCommand Command;
        public Point Location;
        public Point TargetLocation;
        public Rectangle HitBox;
        public const int  BulletSize = 32;
        public int Frame;

        public void SetHitBox()
        {
            HitBox = new Rectangle(Location.X, Location.Y,
                Sprite.SpriteSize.Width / BulletSize,
                Sprite.SpriteSize.Height / BulletSize);
        }
    }
}
