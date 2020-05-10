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
       private Game game;
       private Level currentLevel;
        public FieldControl(Game game)
        {
            InitializeComponent();
            this.game = game;
            currentLevel = game.CurrentLevel;
            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += TimerEvent;
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var imagesDirectory = new DirectoryInfo(@"Resourses\Sprites");
            var f = imagesDirectory.GetFiles("*.png");
            var img = Image.FromFile(f[0].FullName);
            e.Graphics.DrawImage((Bitmap)img, new Point(10, 10));
        }

        private void TimerEvent(object sender, EventArgs args)
        {
            // throw new NotImplementedException();
            Invalidate();
        }
    }
}
