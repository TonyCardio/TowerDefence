using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class Game
    {
        GameStage stage = GameStage.MainMenu;
        public event Action<GameStage> StateChanged;
        public Player Player { get; set; }
        public List<Level> Levels { get; set; }

        public Game()
        {
            Levels = LoadLevels();
        }

        private List<Level> LoadLevels()
        {
            var levels = new List<Level>();
            foreach (var lvlName in LevelsLoader.GetLevelsNames())
                levels.Add(LevelsLoader.LoadLevelByName(lvlName));
            return levels;
        }

        private void RunLevel(string levelName)
        {
        }

        public void StartChooseLevel()
        {
            ChangeStage(GameStage.ChoosingLevel);
        }

        public void StartLevel(string levelName)
        {
            RunLevel(levelName);
            ChangeStage(GameStage.RunningLevel);
        }

        private void ChangeStage(GameStage stage)
        {
            this.stage = stage;
            StateChanged?.Invoke(stage);
        }
    }
}
