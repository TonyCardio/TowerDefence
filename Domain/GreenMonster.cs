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
        public GreenMonster(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 20 , 5, 2) { }

        /*
         health - 20
         punchPower - 5
         speed - 2
        */

    }
}
