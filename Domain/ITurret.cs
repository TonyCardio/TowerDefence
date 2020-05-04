namespace TowerDefence.Domain
{
    public interface ITurret
    {
        int Cost { get; set; }
        int ShotPower { get; set; }
        int CoolDown { get; set; }
    }
}
