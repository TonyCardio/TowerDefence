using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
   public class GreenMonster : Enemy
    {
        public GreenMonster(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 20 , 5, 2, 3, 3, 3, 3, 6 , 8) { }

        /*
         health - 20
         punchPower - 5
         speed - 2
         countMoveLeftFrames - 3
         countMoveRightFrames - 3
         countMoveUpFrames - 3
         countMoveDownFrames - 3
         width - I don`t know - вставил рандомно
         height - I don`t know - вставил рандомно
        */

    }
}
