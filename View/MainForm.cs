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
            InitializeComponent();

            game = new Game();
            game.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.MainMenu:
                    ShowMainMenu();
                    break;
                case GameStage.ChoosingLevel:
                    ShowLevels();
                    break;
                case GameStage.RunningLevel:
                    ShowLevelScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                default:
                    ShowMainMenu();
                    break;
            }
        }

        private void ShowFinishedScreen()
        {
            throw new NotImplementedException();
        }

        private void ShowLevelScreen()
        {
            throw new NotImplementedException();
        }

        private void ShowLevels()
        {
            throw new NotImplementedException();
        }

        private void ShowMainMenu()
        {
            throw new NotImplementedException();
        }
    }
}
