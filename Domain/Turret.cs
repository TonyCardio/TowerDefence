using System;

namespace TowerDefence.Domain
{
    public class Turret : ITurret, ICreature
    {
        // положение на поле x y  -необязательное-
        public int Cost { get; set; }
        public int ShotPower { get; set; }
        public int CoolDown { get; set; }
        public int ShotsBeforeCoolDown { get; set; }
        public Direction DirectionType { get; set; }
        public bool IsAlive { get; set; } = true;

        public Turret(int cost, int shotPower, int shotsBeforeCoolDown, int coolDown, Direction direction)
        {
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
                if (Game.CurrentLevel.Field.PointBelongsMap(x - 1, y))
                    Game.CurrentLevel.Field.Cells[x - 1, y].Creature = bullet;
            if (DirectionType == Direction.Up)
                if (Game.CurrentLevel.Field.PointBelongsMap(x, y + 1))
                    Game.CurrentLevel.Field.Cells[x, y + 1].Creature = bullet;
            return new MovingCommand();
        }

        public Action ActionInConflict(ICreature conflictedObject) { return () => { }; }

        // цена
        // урон
        // кол-во выстрелов за определённое время
    }
}
