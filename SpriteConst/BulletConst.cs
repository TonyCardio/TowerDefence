using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.SpriteConst
{
    public class BulletConst : ISpriteConst
    {
        public Rectangle rightRect { get; private set; } = new Rectangle(540, 375, 35, 25);
        public Rectangle leftRect { get; private set; } = new Rectangle(540, 375, 35, 25);
        public Rectangle upRect { get; private set; } = new Rectangle(540, 375, 35, 25);
        public Rectangle downRect { get; private set; } = new Rectangle(540, 375, 35, 25);
        public int offset { get; private set; } = 0;

        public Rectangle GetRectPerFrame(int frame, Rectangle currentRect)
        {
            return currentRect;
        }
    }
}
