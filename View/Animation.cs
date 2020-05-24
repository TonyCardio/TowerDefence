using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Domain;
using System.Drawing;
using System.IO;
using TowerDefence.SpriteConst;

namespace TowerDefence.View
{
    public class Animation
    {
        public const int ElementSize = 32;
        public static int FrameCount;
        public static int SpriteShiftCoeff;
        public Sprite Sprite;
        public ICreature Creature;
        public MovingCommand Command;
        public Point LocationOnControl;
        public Point LocationOnField;
        public Point TargetLocation;
        public CellType CellType;
        public Rectangle HitBox;
        public ISpriteConst spriteConst;
        public const int  BulletSize = 32;
        public int Frame;

        public Animation(ICreature creature, MovingCommand command, Point location, int frame, CellType type)
        {
            this.CellType = type;
            Creature = creature;
            Command = command;
            LocationOnField = location;
            TargetLocation = new Point(location.X + command.DeltaX, location.Y + command.DeltaY);
            Frame = frame;
            //SetSprite();
            //LocationOnControl = new Point(location.X * Sprite.SpriteSize.Width + Sprite.SpriteSize.Width,
            //    location.Y * Sprite.SpriteSize.Height - Sprite.SpriteSize.Height);
            //LocationOnControl = new Point(location.X * 32, location.Y * 32 - Sprite.SpriteSize.Height/2);
        }

        public Animation()
        {

        }

        public void ChangeControlLoc()
        {
            if (Command.DeltaY == 0 && Command.DeltaX == 0)
                return;
            
            //var x = LocationOnControl.X + Command.DeltaX * (Sprite.SpriteSize.Width / 6);
            //var y = LocationOnControl.Y + Command.DeltaY * (Sprite.SpriteSize.Height / 4);
            var x = LocationOnControl.X + Command.DeltaX * SpriteShiftCoeff;
            var y = LocationOnControl.Y + Command.DeltaY * SpriteShiftCoeff;
            var rect = Sprite.SpriteSize;
            var newRect = spriteConst.GetRectPerFrame(Frame, rect);
            Sprite.SetTextureRect(newRect);
            LocationOnControl = new Point(x, y);
        }

        public Animation(CellType type, Point location)
        {
            SetFieldElement(type, location);
        }

        public void SetFieldElementSprite()
        {
            var rect = new Rectangle(0, 0, ElementSize, ElementSize);
            Bitmap bitmap = null;
            if (CellType == CellType.Empty)
                bitmap = new Bitmap(GetPath("Empty.png"));
            else if (CellType == CellType.Road || CellType == CellType.EnemySpawn)
                bitmap = new Bitmap(GetPath("Road.png"));
            Sprite = new Sprite(bitmap, rect);
        }

        public void SetFieldElement(CellType type, Point location)
        {
            LocationOnControl = new Point(location.X * ElementSize, location.Y * ElementSize);
            LocationOnField = location;
            CellType = type;
        }

        public void SetHitBox(Point location)
        {
            HitBox = new Rectangle(location.X, location.Y,
               location.X + Sprite.SpriteSize.Width / BulletSize,
               location.Y + Sprite.SpriteSize.Height / BulletSize);
        }

        public string GetPath(string fileName)
        {
            return Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
                "Resourses\\Sprites\\" + fileName);
        }

        public void SetSprite()
        {
            ///Пока не придумал как хранить точки для начала анимаций 
            ///Поэтому только наброски
            ISpriteConst spriteConst = null;
            Bitmap img = null;
            string path = null;
            Rectangle rectangle;
            if (Creature == null)
                return;
            if (Creature is ShortSkeleton)
            {
                path = GetPath("SmallSkeleton.png");
                spriteConst = new SmallSkeletonConst();
            }
            else if (Creature is GreenMonster)
            {
                path = GetPath("HighSkeletonAndGreenMonster.png");
                spriteConst = new GreenMonsterConst();
            }
            else if (Creature is Bullet)
            {
                path = GetPath("SmallSkeleton.png");
                spriteConst = new BulletConst();
            }
            else if (Creature is HighSkeleton)
            {
                path = GetPath("HighSkeletonAndGreenMonster.png");
                spriteConst = new HighSkeletonConst();
            }
            else if (Creature is Turret)
            {
                path = GetPath("TurretSprite.png");
                spriteConst = new TurretConst();
            }
            else
                throw new Exception("Не описанная сущность");
            img = new Bitmap(path);
            rectangle = GetRectanglePerDirection(spriteConst, Command.direction);
            Sprite = new Sprite(img, rectangle);
            this.spriteConst = spriteConst;
            SetHitBox(LocationOnField);
            LocationOnControl = new Point(LocationOnField.X * ElementSize, 
                LocationOnField.Y * ElementSize - Sprite.SpriteSize.Height / 2);
            //....
        }

        Rectangle GetRectanglePerDirection(ISpriteConst spriteConst, Direction direction)
        {
            Rectangle rectangle = default(Rectangle);
            if (direction == Direction.Up)
                rectangle = spriteConst.upRect;
            if (direction == Direction.Down)
                rectangle = spriteConst.downRect;
            if (direction == Direction.Left)
                rectangle = spriteConst.leftRect;
            if (direction == Direction.Right)
                rectangle = spriteConst.rightRect;
            if (direction == Direction.Stay)
                rectangle = spriteConst.leftRect;
            return rectangle;
        }
    }
}
