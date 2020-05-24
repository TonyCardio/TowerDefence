using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefence.SpriteConst
{
    public class TurretConst : ISpriteConst
    {
        public Rectangle rightRect { get; private set; } = new Rectangle(5, 145, 45, 45);
        public Rectangle leftRect { get; private set; } = new Rectangle(1, 400, 45, 45);
        public Rectangle upRect { get; private set; } = new Rectangle(5, 270, 45, 45);
        public Rectangle downRect { get; private set; } = new Rectangle(5, 10, 45, 45);
        public int offset { get; } = 0;

        public Rectangle GetRectPerFrame(int frame, Rectangle currentRect)
        {
            var newRect = new Rectangle(currentRect.X + offset * (frame % 3),
                currentRect.Y, currentRect.Width, currentRect.Height);
            return newRect;
        }
    }
}
