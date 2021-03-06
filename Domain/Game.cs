﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public static class Game
    {
        public static GameStage Stage { get; private set; } = GameStage.MainMenu;
        public static event Action<GameStage> StateChanged;

        public static List<Level> Levels { get; set; }
        public static Level CurrentLevel = null;

        static Game()
        {
            Levels = LoadLevels();
        }

        public static void RunLevel()
        {
            CurrentLevel.Run();
            ChangeStage(GameStage.RunningLevel);
        }

        private static List<Level> LoadLevels()
        {
            var levels = new List<Level>();
            foreach (var lvlName in LevelsLoader.GetLevelsNames())
                levels.Add(LevelsLoader.LoadLevelByName(lvlName));
            return levels;
        }

        public static void StartChooseLevel()
        {
            ChangeStage(GameStage.ChoosingLevel);
        }

        public static void ChoseLevel(string levelName)
        {
            CurrentLevel = Levels
                .Where(lvl => lvl.Name == levelName)
                .FirstOrDefault();
            ChangeStage(GameStage.LevelNotStarted);
        }

        public static void LoseLevel()
        {
            CurrentLevel?.Lose();
            ChangeStage(GameStage.Finished);
        }

        public static void WinLevel()
        {
            ChangeStage(GameStage.Finished);
        }

        private static void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StateChanged?.Invoke(stage);
        }
    }
}
