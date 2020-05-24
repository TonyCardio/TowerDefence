using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefence.SpriteConst
{
    public class SmallSkeletonConst : ISpriteConst
    {
        public Rectangle rightRect { get; private set; } = new Rectangle(65, 110, 30, 40);
        public Rectangle leftRect { get; private set; } = new Rectangle(65, 60, 30, 40);
        public Rectangle upRect { get; private set; } = new Rectangle(255, 15, 30, 40);
        public Rectangle downRect { get; private set; } = new Rectangle(210, 160, 30, 40);
        public int offset { get; private set; } = 48;

        public Rectangle GetRectPerFrame(int frame, Rectangle currentRect)
        {
            var newRect = new Rectangle(currentRect.X + offset * (frame % 3),
                currentRect.Y, currentRect.Width, currentRect.Height);
            return newRect;
        }
    }
}
