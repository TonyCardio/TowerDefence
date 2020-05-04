using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Domain
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Turret> Turrets { get; set; }
        public Castle Castle { get; set; }


        public Field(int width, int height)
        {
            Width = width;
            Height = height;
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
