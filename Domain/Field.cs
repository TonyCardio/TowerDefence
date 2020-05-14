using System;
using System.Drawing;

namespace TowerDefence.Domain
{
    public class Field
    {
        public Cell[,] Cells { get; set; }
        public Point CastlePos { get; set; }
        public Point EnemySpawnPos { get; set; }
        public int Width { get => Cells.GetLength(0); }
        public int Height { get => Cells.GetLength(1); }
        public Castle Castle { get; set; }

        public Field(Cell[,] cells, Point castlePosition, Point enemySpawnPosition)
        {
            Cells = cells;
            CastlePos = castlePosition;
            EnemySpawnPos = enemySpawnPosition;
        }

        public bool PutTurret(Turret turret, Point point)
        {
            if (point.X < 0 && point.X >= Width &&
                point.Y < 0 && point.Y >= Height)
                throw new ArgumentException();
            if (Cells[point.X, point.Y]?.Creature as Turret != null)
                // Мб вернуть false если захотим реализовать подсвечивание красненьким
                throw new InvalidOperationException();
            if (Cells[point.X, point.Y].Type == CellType.Empty)
            {
                Cells[point.X, point.Y] = new Cell(CellType.Empty, point, turret);
                return true;
            }
            return false;
            /*
             * Tests:
             *  Разместить -> проверить размещение
             *  Размещение за пределами
             *  Размещение на дороге
             *  Размещение размещённой турели в допустимую позицию
             *  Размещение размещённой турели в недопустимую позицию
             */
        }
    }
}