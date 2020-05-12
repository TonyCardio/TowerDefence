using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TowerDefence.Domain;


namespace TowerDefence.View
{
    public partial class FieldControl : UserControl
    {
        private Level currentLevel;
        private FieldState fieldState;
        int frames;
        Timer tmrSimGame = new Timer();
        Timer tmrCheckInitLevel = new Timer();

        public FieldControl()
        {
            InitializeComponent();
            currentLevel = Game.CurrentLevel;
            tmrSimGame.Interval = 20;
            tmrSimGame.Tick += TimerEvent;
            tmrCheckInitLevel.Interval = 3;
            tmrCheckInitLevel.Tick += CheckInitLevel;
            tmrCheckInitLevel.Start();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //var path = Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),
            //   @"Resourses\Sprites\HighSkeletonAndGreenMonster.png");
            //var img = new Bitmap(path);
            //e.Graphics.DrawImage(img, new Point(10, 10));
            if (fieldState != null)
                DrawField(e);
        }

        private void DrawField(PaintEventArgs e)
        {
            foreach (var animation in fieldState.StaticObject)
                e.Graphics.DrawImage(animation.Sprite.TextureInRect, animation.LocationOnControl);
            foreach (var animation in fieldState.Animations)
                e.Graphics.DrawImage(animation.Sprite.TextureInRect, animation.LocationOnControl);
        }

        private void TimerEvent(object sender, EventArgs args)
        {
            if (frames == 0)
                fieldState.BeginAct();
            foreach (var e in fieldState.Animations)
            {
                e.ChangeControlLoc();
                e.Frame = frames;
            }
            if (frames == 4)
                fieldState.EndAct();
            frames++;
            if (frames == 5)
                frames = 0;
            Invalidate();
        }

        private void CheckInitLevel(object sender, EventArgs args)
        {
            if (Game.CurrentLevel != null)
            {
                currentLevel = Game.CurrentLevel;
                fieldState = new FieldState(currentLevel.Field);
                Game.RunLevel();
                tmrSimGame.Start();
                tmrCheckInitLevel.Stop();
            }
        }
    }
}
