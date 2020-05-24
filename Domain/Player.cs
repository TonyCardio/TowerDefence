namespace TowerDefence.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public int MoneyCount { get; set; }
        public bool IsLost { get; set; }

        public Player(string name, int moneyCount)
        {
            Name = name;
            MoneyCount = moneyCount;
            IsLost = false;
        }
    }
}
