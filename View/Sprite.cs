using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefence.View
{
    public class Sprite
    {
        public Bitmap TextureInRect { get; private set; }
        public Point Position { get; private set; }
        public Rectangle SpriteSize { get; private set; }
        Bitmap texture;

        public Sprite(Bitmap texture, Rectangle rectangle)
        {
            SetTexture(texture);
            SpriteSize = rectangle;
            SetTextureRect(rectangle);
        }
        //Тут хз, может бытть лучше будет путь до текстуры передавать
        public void SetTexture(Bitmap texture)
        {
            this.texture = texture;
        }
        public void SetTextureRect(Rectangle rectangle)
        {
            TextureInRect = texture.Clone(rectangle, texture.PixelFormat);
        }

        public void SetPosition(Point point)
        {
            Position = point;
        }
    }
}
