using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Domain
{
    public class Field
    {
        public FieldCell[,] Cells { get; set; }
        public Point CastlePos { get; set; }
        public Point EnemySpawnPos { get; set; }
        public int Width { get { return Cells.GetLength(0); } }
        public int Height { get { return Cells.GetLength(1); } }
        public List<Turret> Turrets { get; set; }
        public Castle Castle { get; set; }

        public Field(FieldCell[,] cells, Point castlePosition, Point enemySpawnPosition)
        {
            Cells = cells;
            CastlePos = castlePosition;
            EnemySpawnPos = enemySpawnPosition;
        }

        public void AddTurret(Turret turret)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ITurret> GetTurrets()
        {
            throw new NotImplementedException();
        }

        public bool PutTurret(ITurret turret, Point point)
        {
            throw new NotImplementedException();

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
