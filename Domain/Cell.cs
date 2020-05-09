using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace TowerDefence.Domain
{
    public class Cell
    {
        public CellType Type { get; private set; }
        public ICreature Creature { get; set; };
        public Point Coordinates { get; set; }

        public Cell(CellType type, Point coordinates, ICreature creature = null)
        {
            Type = type;
            Coordinates = coordinates;
            Creature = creature;
        }
    }
}
