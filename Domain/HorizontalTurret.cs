using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class HorizontalTurret : Turret
    {
        public HorizontalTurret() : base(50, 10, 10, 5, Direction.Left) { }                
            /*
               cost- 50
               shotPower - 10
               coolDown - 10
            */
    }
}
