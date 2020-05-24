using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefence.SpriteConst
{
    interface ISpriteConst
    {
        Rectangle rightRect { get; }
        Rectangle leftRect { get; }
        Rectangle upRect { get; }
        Rectangle downRect { get; }
        int offset { get; }
        Rectangle GetRectPerFrame(int frame, Rectangle currentRect);
    }
}
