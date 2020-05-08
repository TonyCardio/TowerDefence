using System.Drawing;

namespace TowerDefence.Domain
{
    public class Cell
    {
        public CellType Type { get; private set; }
        public Point Coordinates { get; set; }
        public bool IsTurret { get; set; }
        public int IsEnemy { get; set; }

        public Cell(CellType type, Point coordinates)
        {
            Type = type;
            Coordinates = coordinates;
        }
    }
}
