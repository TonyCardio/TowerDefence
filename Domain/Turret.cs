namespace TowerDefence.Domain
{
    public class Turret : ITurret
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
        // цена
        // урон
        // кол-во выстрелов за определённое время
    }
}
