using System;
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

        public Level(string name, Field field, int wavesCount)
        {
            Name = name;
            Field = field;
            WavesCount = wavesCount;
            PathSpawnToCastle = CreateEnemysPath();
        }


        private List<Point> CreateEnemysPath()
        {
            var path = Extensions.BFS(Field, Field.EnemySpawnPos, Field.CastlePos);
            var result = new List<Point>();
            result.Add(path.Value);
            while ((path?.Previous ?? null) != null)
            {
                result.Add(path.Previous.Value);
                path = path.Previous;
            }
            return result.Count != 1 ? result : throw new ArgumentException("Can`t find path to Castle");
        }
    }
}
