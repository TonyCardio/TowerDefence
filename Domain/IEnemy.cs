namespace TowerDefence.Domain
{
    public interface IEnemy
    {
        int Health { get; set; }
        int PunchPower { get; set; }
    }
}
