using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TowerDefence.SpriteConst
{
    public class GreenMonsterConst : ISpriteConst
    {
        public Rectangle rightRect { get; private set; } = new Rectangle(5, 150, 25, 45);
        public Rectangle leftRect { get; private set; } = new Rectangle(5, 90, 25, 45);
        public Rectangle upRect { get; private set; } = new Rectangle(5, 215, 25, 40);
        public Rectangle downRect { get; private set; } = new Rectangle(5, 25, 25, 40);
        public int offset { get; private set; } = 30;

        public Rectangle GetRectPerFrame(int frame, Rectangle currentRect)
        {
            var newRect = new Rectangle(currentRect.X + offset * (frame % 3),
                currentRect.Y, currentRect.Width, currentRect.Height);
            return newRect;
        }
    }
}
