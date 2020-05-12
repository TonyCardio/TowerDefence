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
        public Direction TypeTurretInDirection { get; set; }

        public Turret(int cost, int shotPower, int shotsBeforCoolDown, int coolDown, Direction direction)
        {
            Cost = cost;
            ShotPower = shotPower;
            CoolDown = coolDown;
            ShotsBeforCoolDown = shotsBeforCoolDown;
            TypeTurretInDirection = direction;
        }

        public MovingCommand Act(int x, int y)
        {
            var bullet = new Bullet(TypeTurretInDirection);
            if (TypeTurretInDirection == Direction.Left)
                bullet.Act(x - 1, y);
            if (TypeTurretInDirection == Direction.Up)
                bullet.Act(x, y + 1);
            return new MovingCommand();
        }

        public Action ActionInConflict(ICreature conflictedObject) => null;

        // цена
        // урон
        // кол-во выстрелов за определённое время
    }
}
