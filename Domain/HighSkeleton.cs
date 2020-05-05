using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    class HighSkeleton : Enemy
    {
        public HighSkeleton(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 30, 10, 1, 6, 6, 6, 6, 5 , 10) { }
        /*
         health - 30
         punchPower - 10
         speed - 1
         countMoveLeftFrames - 6
         countMoveRightFrames - 6
         countMoveUpFrames - 6
         countMoveDownFrames - 6
         width - I don`t know - вставил рандомно
         height - I don`t know - вставил рандомно
        */

    }
}
