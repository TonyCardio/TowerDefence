﻿using System;
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
        private FieldState fieldState;
        int frames;
        Timer tmrSimGame = new Timer();
        Timer tmrCheckInitLevel = new Timer();
        Animation mouseAnimation;

        public FieldControl()
        {
            InitializeComponent();
            tmrSimGame.Interval = 17;
            tmrSimGame.Tick += TimerEvent;
            tmrCheckInitLevel.Interval = 3;
            tmrCheckInitLevel.Tick += CheckInitLevel;
            tmrCheckInitLevel.Start();
            DoubleBuffered = true;

            //Количество кадров на анимацию 
            Animation.FrameCount = 8;
            Animation.SpriteShiftCoeff = Animation.ElementSize / Animation.FrameCount;

            var button = new Button();
            button.Text = "Выбор башни";
            button.Size = new Size(100, 100);
            button.Location = new Point(300, 500);
            button.Click += ButtonClick;
            Controls.Add(button);

            MouseDoubleClick += SpawnTurret;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (fieldState != null)
                DrawField(e);
            DrawMouseMove(e);

            //Для дебага  координат 
            var mousePositionOnControl = PointToClient(MousePosition);
            var strLoc = (mousePositionOnControl.X / 32).ToString() + "   " + (mousePositionOnControl.Y / 32).ToString();
            var brush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(strLoc, new Font("Arial", 16), brush, new PointF(500, 500));
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
            {
                fieldState.BeginAct();
                foreach (var anim in fieldState.Animations)
                    anim.SetSprite();
                foreach (var staticObject in fieldState.StaticObject)
                    staticObject.SetFieldElementSprite();
            }
            foreach (var e in fieldState.Animations)
            {
                e.Frame = frames;
                e.ChangeControlLoc();
            }
            if (frames == Animation.FrameCount)
                fieldState.EndAct();
            frames++;
            if (frames == Animation.FrameCount + 1)
                frames = 0;
            Invalidate();
        }

        private void CheckInitLevel(object sender, EventArgs args)
        {
            if (Game.CurrentLevel != null)
            {
                fieldState = new FieldState(Game.CurrentLevel.Field);
                Game.RunLevel();
                ClientSize = new Size(fieldState.Field.Width* Animation.ElementSize, 1000);
                tmrSimGame.Start();
                tmrCheckInitLevel.Stop();
            }
        }

        private void ButtonClick(object sender, EventArgs args)
        {
            mouseAnimation = new Animation();
            mouseAnimation.Sprite = new Sprite(new Bitmap(mouseAnimation.GetPath("MousePos.png")),
                new Rectangle(0, 0, 32, 32));
            mouseAnimation.Creature = new VerticalTurret(Game.CurrentLevel.Field);
        }

        private void DrawMouseMove(PaintEventArgs e)
        {
            if (mouseAnimation == null)
                return;
            var mousePositionOnControl = PointToClient(MousePosition);
            e.Graphics.DrawImage(mouseAnimation.Sprite.TextureInRect, mousePositionOnControl);
        }

        private void SpawnTurret(object sender, EventArgs args)
        {
            if (mouseAnimation == null)
                return;
            var mousePositionOnControl = PointToClient(MousePosition);
            var mouseLocOnField = new Point(mousePositionOnControl.X / Animation.ElementSize,
                mousePositionOnControl.Y / Animation.ElementSize);
            fieldState.Field.PutTurret((Turret)mouseAnimation.Creature, mouseLocOnField);
            mouseAnimation = null;
        }
    }
}
