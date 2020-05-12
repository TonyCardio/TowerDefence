using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Domain;
using System.Drawing;
using System.IO;

namespace TowerDefence.View
{
    public class Animation
    {
        public Sprite Sprite;
        public ICreature Creature;
        public MovingCommand Command;
        public Point LocationOnControl;
        public Point LocationOnField;
        public Point TargetLocation;
        public Rectangle HitBox;
        public const int  BulletSize = 32;
        public int Frame;

        public Animation(ICreature creature, MovingCommand command, Point location, int frame)
        {
            Creature = creature;
            Command = command;
            LocationOnField = location;
            TargetLocation = new Point(location.X + command.DeltaX, location.Y + command.DeltaY);
            Frame = frame;
            SetSprite();
            SetHitBox(location);
            //LocationOnControl = new Point(location.X * Sprite.SpriteSize.Width + Sprite.SpriteSize.Width,
            //    location.Y * Sprite.SpriteSize.Height - Sprite.SpriteSize.Height);
            LocationOnControl = new Point(location.X * 32, location.Y * 32 - Sprite.SpriteSize.Height/2);
        }
        public void ChangeControlLoc()
        {
            var x = LocationOnControl.X + Command.DeltaX * (Sprite.SpriteSize.Width / 6);
            var y = LocationOnControl.Y + Command.DeltaY * (Sprite.SpriteSize.Height / 4);
            var rect = Sprite.SpriteSize;
            Frame = Frame < 3 ? Frame : 0;
            var newRect = new Rectangle(rect.X + 30 * Frame, rect.Y, rect.Width, rect.Height);
            Sprite.SetTextureRect(newRect);
            LocationOnControl = new Point(x, y);
        }
        public Animation(CellType type, Point location)
        {
            SetFieldElement(type, location);
        }
        public void SetFieldElement(CellType type, Point location)
        {
            var rect = new Rectangle(0, 0, 32, 32);
            Bitmap bitmap = null;
            if (type == CellType.Empty)
                bitmap = new Bitmap(GetPath("Empty.png"));
            else if (type == CellType.Road)
                bitmap = new Bitmap(GetPath("Road.png"));
            Sprite = new Sprite(bitmap,rect);
            LocationOnControl = new Point(location.X * 32, location.Y * 32);
            LocationOnField = location;
        }

        public void SetHitBox(Point location)
        {
            HitBox = new Rectangle(location.X, location.Y,
               location.X + Sprite.SpriteSize.Width / BulletSize,
               location.Y + Sprite.SpriteSize.Height / BulletSize);
        }
        string GetPath(string fileName)
        {
            return Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Resourses\\Sprites\\" + fileName);
        }
        public void SetSprite()
        {
            ///Пока не придумал как хранить точки для начала анимаций 
            ///Поэтому только наброски
            var path = GetPath("HighSkeletonAndGreenMonster.png");
            var img = new Bitmap(path);
            var rect = new Rectangle(5, 150, 25, 45);
            if (Creature is ShortSkeleton)
            {
                Sprite = new Sprite(img,rect);
                Sprite.SetPosition(new Point(5, 150));
            }
            else if (Creature is GreenMonster)
            {
                Sprite = new Sprite(img,rect);
                Sprite.SetPosition(new Point(5, 150));
            }
            else
            {
                Sprite = new Sprite(img, rect);
                Sprite.SetPosition(new Point(0, 0));
            }
            //....
                
        }
    }
}
