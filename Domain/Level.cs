using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace TowerDefence.Domain
{
    public class Level
    {
        public string Name { get; set; }
        public Field Field { get; set; }
        public List<Point> PathSpawnToCastle { get; set; }
        public int WavesCount { get; set; }

        public Level(string name, FieldCell[,] field, int wavesCount)
        {
            Name = name;
            Field = new Field(field);
            WavesCount = wavesCount;
        }
    }
}
