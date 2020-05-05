using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class ShortSkeleton : Enemy
    {
        public ShortSkeleton(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 25, 5, 2, 8 , 8 , 8 , 8, 6 , 8) { }

        /*
         health - 25
         punchPower - 5
         speed - 2
         countMoveLeftFrames - 8
         countMoveRightFrames - 8
         countMoveUpFrames - 8
         countMoveDownFrames - 8
         width - 
         height - 
         */
    }
}
