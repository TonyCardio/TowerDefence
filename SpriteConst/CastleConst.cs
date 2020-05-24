using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefence.SpriteConst
{
    class CastleConst : ISpriteConst
    {
        public Rectangle rightRect { get; private set; } = new Rectangle(0, 0, 45, 45);
        public Rectangle leftRect { get; private set; } = new Rectangle(0, 0, 45, 45);
        public Rectangle upRect { get; private set; } = new Rectangle(0, 0, 45, 45);
        public Rectangle downRect { get; private set; } = new Rectangle(0, 0, 45, 45);
        public int offset { get; private set; } = 0;

        public Rectangle GetRectPerFrame(int frame, Rectangle currentRect)
        {
            return currentRect;
        }
    }
}
