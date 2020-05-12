using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class HighSkeleton : Enemy
    {
        public HighSkeleton(List<Point> pathSpawnToCastle) : base(pathSpawnToCastle, 30, 10, 1) { }
        /*
         health - 30
         punchPower - 10
         speed - 1
        */

    }
}
