using System;

namespace TowerDefence.Domain
{
    public class Turret : ITurret, ICreature
    {
        // положение на поле x y  -необязательное-
        public int Cost { get; set; }
        public int ShotPower { get; set; }
        public int CoolDown { get; set; }
        public int ShotsBeforCoolDown { get; set; }

        public Turret(int cost, int shotPower, int shotsBeforCoolDown, int coolDown)
        {
            Cost = cost;
            ShotPower = shotPower;
            CoolDown = coolDown;
            ShotsBeforCoolDown = shotsBeforCoolDown;
        }

        public MovingCommand Act(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Action ActionInConflict(ICreature conflictedObject)
        {
            throw new NotImplementedException();
        }
        // цена
        // урон
        // кол-во выстрелов за определённое время
    }
}
