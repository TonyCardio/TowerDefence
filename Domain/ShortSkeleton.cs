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
        public ShortSkeleton(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 25, 10, 1, 8 , 8 , 8 , 8, 6 , 8) { }

        /*
         health - 25
         punchPower - 10
         speed - 1
         countMoveLeftFrames - 8
         countMoveRightFrames - 8
         countMoveUpFrames - 8
         countMoveDownFrames - 8
         width - 
         height - 
         */
    }
}
