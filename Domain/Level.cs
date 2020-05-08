using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace TowerDefence.Domain
{
    public class Level
    {
        public string Name { get; set; }
        public Field Field { get; set; }
        public List<Point> PathSpawnToCastle { get; set; }
        public int WavesCount { get; set; }
        public int EnemiesPerWaveCount { get; set; }
        public bool IsWave { get; set; }
        private readonly HashSet<Enemy> enemies = new HashSet<Enemy>();
        private System.Timers.Timer waveTimer = new System.Timers.Timer();

        public event Action EnemyWave;

        public Level(string name, Field field, List<Point> pathToCastle, int wavesCount)
        {
            // Добавить в Levels, LevelsLoader и этот конструктор
            EnemiesPerWaveCount = 9;
            Name = name;
            Field = field;
            WavesCount = wavesCount;
            PathSpawnToCastle = pathToCastle;
            waveTimer.Interval = 20000;
            waveTimer.Elapsed += OnWaveStart;
            waveTimer.AutoReset = true;
        }

        public void Run()
        {
            waveTimer.Start();
        }

        private void OnWaveStart(object sender, System.Timers.ElapsedEventArgs e)
        {
            CrateEnemies();
            if (WavesCount <= 0)
            {
                waveTimer.Stop();
                waveTimer.Dispose();
            }
        }

        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
                enemy.MakeStep();
        }

        private void CrateEnemies()
        {
            for (var i = 0; i < EnemiesPerWaveCount; i++)
            {
                var enemy = i >= EnemiesPerWaveCount / 3 ?
                            i >= 2 * (EnemiesPerWaveCount / 3) ?
                            (Enemy)new HighSkeleton(PathSpawnToCastle) :
                            (Enemy)new ShortSkeleton(PathSpawnToCastle) :
                        (Enemy)new GreenMonster(PathSpawnToCastle);
                MoveEnemies();
            }
            WavesCount--;
            EnemyWave?.Invoke();
        }
    }
}
