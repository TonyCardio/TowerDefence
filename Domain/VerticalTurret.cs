using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class VerticalTurret : Turret
    {
        public VerticalTurret(Field field) : base(field, 50, 10, 10, 5, Direction.Up) { }

        /*
          cost - 50
          shotPower - 10
          coolDown - 10
        */
    }
}
