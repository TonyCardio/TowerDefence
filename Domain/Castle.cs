namespace TowerDefence.Domain
{
    public class Castle
    {
        public int Health { get; set; } = 100;
        public bool IsDestroyed() => Health <= 0;
    }
}
