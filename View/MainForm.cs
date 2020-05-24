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
        public MainForm()
        {
            DoubleBuffered = true;
            InitializeComponent();
            Game.StateChanged += OnStageChanged;

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
                case GameStage.LevelNotStarted:
                    ShowScreen(fieldControl);
                    break;
                case GameStage.RunningLevel:
                    ShowScreen(fieldControl);
                    break;
                case GameStage.Finished:
                    ShowScreen(mainMenuControl);
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

        private void HideScreens()
        {
            mainMenuControl.Hide();
            levelsControl.Hide();
            fieldControl.Hide();
        }
    }
}
