using System;
using System.Windows.Forms;
using TowerDefence.Domain;
using System.Drawing;
using System.Linq;

namespace TowerDefence.View
{
    public partial class LevelsControl : UserControl
    {
        private Game game;

        public LevelsControl(Game game)
        {
            this.game = game;
            InitializeComponent();
            foreach (var level in game.Levels)
            {
                var button = new Button();
                button.Text = level.Name;
                button.Size = new Size(300, 35);
                button.Click += ChoseLevel_Click;
                flowLayoutPanel.Controls.Add(button);
            }
        }

        //public void Configure(Game game)
        //{
        //    if (this.game != null)
        //        return;
        //    this.game = game;
        //}

        private void ChoseLevel_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            game.StartLevel(button.Text);
        }
    }
}
