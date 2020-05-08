using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Domain
{
    public class Field
    {
        public Cell[,] Cells { get; set; }
        public Point CastlePos { get; set; }
        public Point EnemySpawnPos { get; set; }
        public int Width { get { return Cells.GetLength(0); } }
        public int Height { get { return Cells.GetLength(1); } }
        public Castle Castle { get; set; }
        private readonly HashSet<ITurret> turrets = new HashSet<ITurret>();

        public Field(Cell[,] cells, Point castlePosition, Point enemySpawnPosition)
        {
            Cells = cells;
            CastlePos = castlePosition;
            EnemySpawnPos = enemySpawnPosition;
        }

        public IReadOnlyList<ITurret> GetTurrets()
        {
            throw new NotImplementedException();
        }

        public bool PutTurret(ITurret turret, Point point)
        {
            if (Cells[point.X, point.Y]?.IsTurret == null)
                throw new InvalidOperationException();
            return true;
            /*
             * Tests:
             *  Разместить -> проверить размещение
             *  Размещение за пределами
             *  Размещение на дороге
             *  Размещение размещённой турели в допустимую позицию
             *  Размещение размещённой турели в недопустимую позицию
             *  
             */
        }
    }
}
