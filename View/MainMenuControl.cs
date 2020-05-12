using System;
using System.Windows.Forms;
using TowerDefence.Domain;

namespace TowerDefence.View
{
    public partial class MainMenuControl : UserControl
    {
        public MainMenuControl()
        {
            InitializeComponent();
            startButton.Click += BeginGame_Click;
        }

        //public void Configure(Game game)
        //{
        //    if (this.game != null)
        //        return;
        //    this.game = game;
        //}

        private void BeginGame_Click(object sender, EventArgs e)
        {
            Game.StartChooseLevel();
        }
    }
}