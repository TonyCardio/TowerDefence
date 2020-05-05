using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TowerDefence.Domain;

namespace TowerDefence.View
{
    public partial class MainForm : Form
    {
        private Game game;
        public MainForm()
        {
            game = new Game();
            InitializeComponent();
            game.StateChanged += OnStageChanged;

            ShowScreen(mainMenuControl);
        }

        private void OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.MainMenu:
                    ShowScreen(mainMenuControl);
                    break;
                case GameStage.ChoosingLevel:
                    ShowScreen(levelsControl);
                    break;
                case GameStage.RunningLevel:
                    ShowLevelScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                default:
                    ShowScreen(mainMenuControl);
                    break;
            }
        }

        private void ShowScreen(UserControl screen)
        {
            HideScreens();
            screen.Show();
        }

        private void ShowFinishedScreen()
        {
            throw new NotImplementedException();
        }

        private void ShowLevelScreen()
        {
            throw new NotImplementedException();
        }

        private void HideScreens()
        {
            mainMenuControl.Hide();
            levelsControl.Hide();
        }
    }
}
