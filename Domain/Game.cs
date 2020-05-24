using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefence.Domain
{
    public class Game
    {
        public GameStage Stage { get; private set; } = GameStage.MainMenu;
        public event Action<GameStage> StateChanged;

        public List<Level> Levels { get; set; }
        public Level CurrentLevel { get; set; }

        public Game()
        {
            Levels = LoadLevels();
        }

        public void RunLevel()
        {
            CurrentLevel.Run();
            ChangeStage(GameStage.RunningLevel);
        }

        private List<Level> LoadLevels()
        {
            var levels = new List<Level>();
            foreach (var lvlName in LevelsLoader.GetLevelsNames())
                levels.Add(LevelsLoader.LoadLevelByName(lvlName));
            return levels;
        }

        public void StartChooseLevel()
        {
            ChangeStage(GameStage.ChoosingLevel);
        }

        public void ChoseLevel(string levelName)
        {
            CurrentLevel = Levels
                .Where(lvl => lvl.Name == levelName)
                .FirstOrDefault();
            ChangeStage(GameStage.LevelNotStarted);
        }

        public void LoseLevel()
        {
            CurrentLevel.Lose();
            ChangeStage(GameStage.Finished);
        }

        private void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StateChanged?.Invoke(stage);
        }
    }
}
