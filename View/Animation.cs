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
        public Point LocationOnMap;
        public Point TargetLocation;
        public Rectangle HitBox;
        public const int  BulletSize = 32;
        public int Frame;

        public Animation(ICreature creature, MovingCommand command, Point location, int frame)
        {
            Creature = creature;
            Command = command;
            TargetLocation = new Point(location.X + command.DeltaX, location.Y + command.DeltaY);
            Frame = frame;
            SetSprite();
            SetHitBox(location);
            LocationOnMap = new Point(location.X * Sprite.SpriteSize.Left,
                location.Y * Sprite.SpriteSize.Height);

        }

        public void SetHitBox(Point location)
        {
            HitBox = new Rectangle(location.X, location.Y,
               location.X + Sprite.SpriteSize.Width / BulletSize,
               location.Y + Sprite.SpriteSize.Height / BulletSize);
        }

        public void SetSprite()
        {
            ///Пока не придумал как хранить точки для начала анимаций 
            ///Поэтому только наброски
            var path = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                @"Resourses\Sprites\HighSkeletonAndGreenMonster.png");
            var img = new Bitmap(path);
            var rect = new Rectangle(0, 0, 30, 30);
            if (Creature is ShortSkeleton)
            {
                Sprite = new Sprite();
                Sprite.SetPosition(new Point(0, 0));
                Sprite.SetTexture((Bitmap)img);
                Sprite.SetTextureRect(rect);
            }
            else if (Creature is GreenMonster)
            {
                Sprite = new Sprite();
                Sprite.SetPosition(new Point(0, 0));
                Sprite.SetTexture((Bitmap)img);
                Sprite.SetTextureRect(rect);
            }
            //....
                
        }
    }
}
