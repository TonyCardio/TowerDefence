using System;
using System.Windows.Forms;
using TowerDefence.Domain;

namespace TowerDefence.View
{
    public partial class MainMenuControl : UserControl
    {
        private Game game;

        public MainMenuControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (this.game != null)
                return;

            this.game = game;

            startButton.Click += LevelsButton_Click;
        }

        private void LevelsButton_Click(object sender, EventArgs e)
        {
            game.ChoseLevel();
        }
    }
}