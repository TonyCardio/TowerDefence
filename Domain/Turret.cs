using System;
using System.Drawing;
using System.IO;

namespace TowerDefence.Domain
{
    public class Turret : ITurret, ICreature
    {
        public Field Field { get; set; }
        public int Cost { get; set; }
        public int ShotPower { get; set; }
        public int CoolDown { get; set; }
        public int ShotsBeforeCoolDown { get; set; }
        public Direction DirectionType { get; set; }
        public bool IsAlive { get; set; } = true;

        public Turret(Field field, int cost, int shotPower, int shotsBeforeCoolDown, int coolDown, Direction direction)
        {
            Field = field;
            Cost = cost;
            ShotPower = shotPower;
            CoolDown = coolDown;
            ShotsBeforeCoolDown = shotsBeforeCoolDown;
            DirectionType = direction;
        }

        public MovingCommand Act(int x, int y)
        {
            var bullet = new Bullet(DirectionType);
            if (DirectionType == Direction.Left)
                Field.ShotBullet(bullet, new Point(x - 1, y));
            if (DirectionType == Direction.Up)
                Field.ShotBullet(bullet, new Point(x, y + 1));
            return new MovingCommand();
        }

        public Action ActionInConflict(ICreature conflictedObject) { return () => { }; }

        // цена
        // урон
        // кол-во выстрелов за определённое время
    }
}
